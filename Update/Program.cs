using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Update
{
    internal class Program
    {
        static object consoleLock = new object();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //string targetExeName = @"D:\軟件安裝包\4.0\2025.8.27\DeviceDataAgent\DeviceDataAgent\DeviceDataAgent\bin\Debug\DeviceDataAgent.exe";
            //string remoteVersionPath = @"\\10.28.42.2\e\Update\bin\Debug\version.json";
            //string localVersionPath = @"D:\軟件安裝包\4.0\2025.8.27\DeviceDataAgent\DeviceDataAgent\DeviceDataAgent\bin\Debug\version.json";
            //string targetFolder = @"D:\軟件安裝包\4.0\2025.8.27\DeviceDataAgent\DeviceDataAgent\DeviceDataAgent\bin";
            string targetExeName = args[0];
            string remoteVersionPath = args[1];
            string localVersionPath = args[2];
            string targetFolder = args[3];
            LogInfo($"主程序路径: {targetExeName}");
            LogInfo($"远程版本文件路径: {remoteVersionPath}");
            LogInfo($"本地版本文件路径: {localVersionPath}");
            LogInfo($"目标更新目录: {targetFolder}");

            if (!File.Exists(targetExeName))
            {
                LogWarn("主程序文件未找到，更新后将重新生成。");
            }

            if (!File.Exists(localVersionPath))
            {
                LogWarn("本地版本文件未找到，将执行完整更新。");
            }
            VersionInfo remoteVersion = JsonConvert.DeserializeObject<VersionInfo>(File.ReadAllText(remoteVersionPath));
            if (!File.Exists(localVersionPath))
            {
                LogWarn("本地版本文件不存在，执行完整更新。");
            }
            else
            {
                VersionInfo localVersion = JsonConvert.DeserializeObject<VersionInfo>(File.ReadAllText(localVersionPath));
                if (remoteVersion.Version == localVersion.Version)
                {
                    LogInfo($"当前版本 [{localVersion.Version}] 已是最新，无需更新。");
                    Thread.Sleep(300);
                    return;
                }
            }
            WaitForMainProgramExit(Path.GetFileNameWithoutExtension(targetExeName));
            CopyFilesRecursivelyWithProgress(remoteVersion.UpdateFolder, targetFolder, remoteVersion.Files);
            LogSuccess("更新完成");
            Thread.Sleep(2000);
            //Console.ReadKey();
        }

        static void WaitForMainProgramExit(string targetExeName)
        {
            string processName = Path.GetFileNameWithoutExtension(targetExeName);
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                LogInfo("未找到主程序进程，可能已退出。");
                return;
            }
            LogInfo($"发现主程序正在运行：{processName}");
            Console.Write("[等待] 正在等待主程序退出 ");
            string[] spinner = { "/", "-", "\\", "|" };
            int spinnerIndex = 0;
            while (true)
            {
                processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0)
                    break;
                Console.Write($"\r[等待] 正在等待主程序退出 {spinner[spinnerIndex]} ");
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(100);
            }
            Console.WriteLine("\r[完成] 主程序已退出，开始更新。     ");
        }

        static string NormalizePath(string path)
        {
            if (path.StartsWith(@"\") && !path.StartsWith(@"\\"))
            {
                path = @"\" + path;
            }
            return path;
        }

        static void CopyFilesRecursivelyWithProgress(string sourceDir, string targetDir, List<string> ignoreList)
        {
            sourceDir = NormalizePath(sourceDir);
            var allFiles = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories)
                                    .Where(f => !IsIgnored(f, ignoreList))
                                    .ToList();
            long totalBytes = allFiles.Sum(f => new FileInfo(f).Length);
            long copiedBytes = 0;
            DateTime startTime = DateTime.Now;
            long lastReportedBytes = 0;
            long refreshThreshold = 100L * 1024; //100KB刷新一次
            foreach (var item in ignoreList)
            {
                LogSkip($"更新黑名单：{item}");
            }
            LogInfo("开始复制更新文件...");
            void CopyDir(string src, string dst)
            {
                if (!Directory.Exists(dst))
                    Directory.CreateDirectory(dst);
                foreach (var file in Directory.GetFiles(src))
                {
                    if (IsIgnored(file, ignoreList)) continue;
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(dst, fileName);
                    try
                    {
                        using (FileStream fsSrc = new FileStream(file, FileMode.Open, FileAccess.Read))
                        using (FileStream fsDst = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[1024 * 1024];
                            int read;
                            while ((read = fsSrc.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fsDst.Write(buffer, 0, read);
                                copiedBytes += read;
                                if (copiedBytes - lastReportedBytes >= refreshThreshold)
                                {
                                    PrintProgress(copiedBytes, totalBytes, startTime);
                                    lastReportedBytes = copiedBytes;
                                }
                            }
                        }
                        LogSuccess($"复制文件：{file} -> {destFile}");
                    }
                    catch (Exception ex)
                    {
                        LogError($"复制失败：{file} -> {destFile}：{ex.Message}");
                    }
                }
                foreach (var dir in Directory.GetDirectories(src))
                {
                    if (IsIgnored(dir, ignoreList)) continue;
                    string dirName = Path.GetFileName(dir);
                    string destDir = Path.Combine(dst, dirName);
                    CopyDir(dir, destDir);
                }
            }
            CopyDir(sourceDir, targetDir);
            PrintProgress(totalBytes, totalBytes, startTime);
            Console.WriteLine();
        }

        /// <summary>
        /// 判断路径是否在黑名单里
        /// </summary>
        static bool IsIgnored(string path, List<string> ignoreList)
        {
            string name = Path.GetFileName(path);
            return ignoreList.Any(ignore =>
                string.Equals(ignore, name, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ignore, path, StringComparison.OrdinalIgnoreCase)
            );
        }

        static void PrintProgress(long copiedBytes, long totalBytes, DateTime startTime)
        {
            double percent = (double)copiedBytes / totalBytes * 100;
            double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
            double speed = copiedBytes / 1024.0 / 1024.0 / (elapsedSeconds > 0 ? elapsedSeconds : 1);
            double remainingSeconds = (totalBytes - copiedBytes) / (speed * 1024.0 * 1024.0);
            int barLength = 30;
            int filledLength = (int)(barLength * percent / 100);
            string progressBar = new string('█', filledLength) + new string('-', barLength - filledLength);
            lock (consoleLock)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"复制进度: {percent:F2}% [{progressBar}] " +
                              $"已拷贝: {copiedBytes / (1024.0 * 1024.0):F2} MB | " +
                              $"速度: {speed:F2} MB/s | " +
                              $"预计剩余: {TimeSpan.FromSeconds(remainingSeconds):hh\\:mm\\:ss}   ");
            }
        }

        static void LogInfo(string message, int depth = 0)
        {
            lock (consoleLock)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{new string(' ', depth * 2)}[INFO] {message}");
                Console.ResetColor();
            }
        }

        static void LogSuccess(string message, int depth = 0)
        {
            lock (consoleLock)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{new string(' ', depth * 2)}[OK  ] {message}");
                Console.ResetColor();
            }
        }

        static void LogError(string message, int depth = 0)
        {
            lock (consoleLock)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{new string(' ', depth * 2)}[FAIL] {message}");
                Console.ResetColor();
            }
        }

        static void LogWarn(string message, int depth = 0)
        {
            lock (consoleLock)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{new string(' ', depth * 2)}[WARN] {message}");
                Console.ResetColor();
            }
        }

        static void LogSkip(string message, int depth = 0)
        {
            lock (consoleLock)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{new string(' ', depth * 2)}[SKIP] {message}");
                Console.ResetColor();
            }
        }
    }

    public class VersionInfo
    {
        public string Version { get; set; }
        public List<string> Files { get; set; }
        public string UpdateFolder { get; set; }

        public VersionInfo()
        {
            Files = new List<string>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
