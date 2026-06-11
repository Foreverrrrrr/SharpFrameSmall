using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpFrameSmall.LogsFolder
{
    public class LogsManage
    {
        private static readonly BlockingCollection<(string log, EventType type)> _logqueue
          = new BlockingCollection<(string, EventType)>();

        private static readonly BlockingCollection<(LogsEventJson log, int days)> _eventqueue
         = new BlockingCollection<(LogsEventJson log, int days)>();

        private static readonly Encoding Utf8NoBom = new UTF8Encoding(false);

        public event Action<DateTime, string> SaveLog;
        public enum EventType
        {
            Normal, Warning, Error
        }
        public static readonly char[] _invisibleChars =
        {
            '\u200E', // LEFT-TO-RIGHT MARK
            '\u200F', // RIGHT-TO-LEFT MARK
            '\u202A', // LTR EMBEDDING
            '\u202B', // RTL EMBEDDING
            '\u202C', // POP DIRECTIONAL FORMATTING
            '\u202D', // LTR OVERRIDE
            '\u202E'  // RTL OVERRIDE
        };


        public readonly List<FolderNode> ClassFolders = new List<FolderNode>
        {
            new FolderNode("Event"),
            new FolderNode("Recipe"),
            new FolderNode("Product"),
            new FolderNode("Result")
            {
                Children =
                {
                    new FolderNode("Pass"),
                    new FolderNode("Fail")
                }
            },
            new FolderNode("Image")
            {
                 Children =
                 {
                    new FolderNode("Pass"),
                    new FolderNode("Fail")
                 }
            },
            new FolderNode("Program")
        };

        public static string Path { get; set; }

        public LogsManage()
        {
            var threadLog = new Thread(LogWorker) { Name = "LogWorker", IsBackground = true };
            threadLog.Start();
            var threadevent = new Thread(EventWorker) { Name = "EventWorker", IsBackground = true };
            threadevent.Start();
        }

        private string RemoveDirectionalChars(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            foreach (char c in _invisibleChars)
            {
                input = input.Replace(c.ToString(), string.Empty);
            }
            return input;
        }

        private void FolderPathCheck(string folderpath, IEnumerable<FolderNode> nodes)
        {
            if (!Directory.Exists(folderpath))
            {
                if (folderpath.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
                    throw new ArgumentException($"路径包含非法字符: {folderpath}");
                Directory.CreateDirectory(folderpath);
            }
            if (Directory.Exists(folderpath))
            {
                foreach (var node in nodes)
                {
                    string currentPath = System.IO.Path.Combine(folderpath, node.Name);
                    if (!Directory.Exists(currentPath))
                        Directory.CreateDirectory(currentPath);
                    if (node.Children.Count > 0)
                        FolderPathCheck(currentPath, node.Children);
                }
            }
        }

        public void NewLogsFolder(string folderpath)
        {
            var path = RemoveDirectionalChars(folderpath);
            Path = path;
            FolderPathCheck(path, ClassFolders);
        }

        public static bool WriteJson<T>(string table, T t) where T : class
        {
            bool ret = false;
            string path = string.Empty;
            path = AppDomain.CurrentDomain.BaseDirectory + @"..\Parameter";
            DirectoryInfo root = new DirectoryInfo(path + "\\");
            FileInfo[] files = root.GetFiles();
            if (Array.Exists(files, x => x.Name == table + ".json"))
            {
                string destinationFile = path + "\\" + table + ".json";
                string serializedResult = JToken.Parse(JsonConvert.SerializeObject(t)).ToString();
                File.WriteAllText(destinationFile, serializedResult, Encoding.UTF8);
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        private void DeleteOldFiles(string folderPath, int daysToKeep = 120)
        {
            try
            {
                var files = Directory.GetFiles(folderPath);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.LastWriteTime < DateTime.Now.AddDays(-daysToKeep))
                    {
                        File.Delete(file);
                        SaveLog?.Invoke(DateTime.Now, $"刪除過期文件: {file}");
                    }
                }
            }
            catch (Exception ex)
            {
                SaveLog?.Invoke(DateTime.Now, $"刪除文件時出錯: {ex.Message}");
            }
        }

        public string SaveEventJson(LogsEventJson logsEvent, int days = 120)
        {
            if (logsEvent == null) return string.Empty;
            _eventqueue.Add((logsEvent, days));
            string jsonContent = JsonConvert.SerializeObject(logsEvent, Formatting.Indented);
            return jsonContent;
        }

        private void EventWorker()
        {
            foreach (var (logsEvent, days) in _eventqueue.GetConsumingEnumerable())
            {
                Thread.Sleep(50);
                try
                {
                    if (Path == null) continue;
                    string jsonContent = JsonConvert.SerializeObject(logsEvent, Formatting.Indented);
                    string eventFolderPath = System.IO.Path.Combine(Path, "Event");
                    if (!Directory.Exists(eventFolderPath))
                        Directory.CreateDirectory(eventFolderPath);
                    CleanOldFiles(eventFolderPath, days);
                    string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss_fff}_change.json"; // 毫秒避免重复
                    string filePath = System.IO.Path.Combine(eventFolderPath, fileName);
                    string tempPath = filePath + ".tmp";
                    File.WriteAllText(tempPath, jsonContent, Encoding.UTF8);
                    File.Move(tempPath, filePath);
                    SaveLog?.Invoke(DateTime.Now, $"EventJson保存到:{filePath}");
                }
                catch (Exception ex)
                {
                    SaveLog?.Invoke(DateTime.Now, $"EventJson保存錯誤: {ex.Message}");
                }
            }
        }

        public string SaveProductJson(LogsProductJson logsProduct, int days = 120)
        {
            if (Path == null)
                throw new Exception("Path路径是空");
            string jsonContent = JsonConvert.SerializeObject(logsProduct, Formatting.Indented);
            string eventFolderPath = System.IO.Path.Combine(Path, "Product");
            CleanOldFiles(eventFolderPath, days);
            if (Directory.Exists(eventFolderPath))
            {
                string fileName = $"{logsProduct.data.USN_ID}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string filePath = System.IO.Path.Combine(eventFolderPath, fileName);
                try
                {
                    File.WriteAllText(filePath, jsonContent, Encoding.UTF8);
                    SaveLog?.Invoke(DateTime.Now, $"ProductJson保存到:{filePath}");
                }
                catch (Exception ex)
                {
                    SaveLog?.Invoke(DateTime.Now, $"ProductJson保存錯誤{filePath}: {ex.Message}");
                }
            }
            return jsonContent;
        }

        public string SaveResultJson(LogsResultJson logsResult, bool result, string sn, int days = 120)
        {
            if (Path == null)
                throw new Exception("Path路径是空");
            string jsonContent = JsonConvert.SerializeObject(logsResult, Formatting.Indented);
            string eventFolderPath = string.Empty;
            if (result)
                eventFolderPath = System.IO.Path.Combine(Path, "Result", "Pass");
            else
                eventFolderPath = System.IO.Path.Combine(Path, "Result", "Fail");

            CleanOldFiles(eventFolderPath, days);
            if (Directory.Exists(eventFolderPath))
            {
                string fileName = $"{sn}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string filePath = System.IO.Path.Combine(eventFolderPath, fileName);
                try
                {
                    File.WriteAllText(filePath, jsonContent, Encoding.UTF8);
                    SaveLog?.Invoke(DateTime.Now, $"ResultJson保存到:{filePath}");
                }
                catch (Exception ex)
                {
                    SaveLog?.Invoke(DateTime.Now, $"ResultJson保存錯誤{filePath}: {ex.Message}");
                }
            }
            return jsonContent;
        }

        private void CleanOldFiles(string directoryPath, int days = 120)
        {
            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (var file in files)
                {
                    try
                    {
                        TimeSpan timeDifference = DateTime.Now - file.LastWriteTime;
                        if (timeDifference.Days > days)
                        {
                            file.Delete();
                            SaveLog?.Invoke(DateTime.Now, $"已刪除過期文件: {file.FullName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        SaveLog?.Invoke(DateTime.Now, $"刪除文件錯誤: {file.FullName}: {ex.Message}");
                    }
                }
            }
        }

        public static void SoftwareLog(string log, EventType type)
        {
            if (Path == null) return;
            _logqueue.Add((log, type));
        }

        private void LogWorker()
        {
            foreach (var (log, type) in _logqueue.GetConsumingEnumerable())
            {
                Thread.Sleep(50);
                try
                {
                    string eventFolderPath = System.IO.Path.Combine(Path, "Event");
                    if (!Directory.Exists(eventFolderPath))
                        Directory.CreateDirectory(eventFolderPath);
                    string fileName = DateTime.Now.ToString("yyyyMMdd") + ".csv";
                    string csvPath = System.IO.Path.Combine(eventFolderPath, fileName);
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string typeName = type.ToString();
                    string line = $"{time},{typeName},{log}";
                    bool newFile = !File.Exists(csvPath);
                    using (var fs = new FileStream(csvPath, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (var sw = new StreamWriter(fs, Utf8NoBom))
                    {
                        if (newFile)
                        {
                            byte[] bom = Encoding.UTF8.GetPreamble();
                            fs.Write(bom, 0, bom.Length);
                            sw.WriteLine("時間,類型,日誌內容");
                        }
                        sw.WriteLine(line);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("日志写入失败：" + ex.Message);
                }
            }
        }
    }

    public class FolderNode
    {
        public string Name { get; }
        public List<FolderNode> Children { get; } = new List<FolderNode>();
        public FolderNode(string name) => Name = name;
        public void AddChild(string childName) =>
            Children.Add(new FolderNode(childName));
    }
}
