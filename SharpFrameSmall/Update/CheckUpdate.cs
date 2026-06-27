using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharpFrameSmall.Update
{
    /// <summary>
    /// 客户端热更新 — 从 HTTP 服务器下载更新文件并重启程序。
    /// Debug 输出到 VS 输出窗口，可替换 Log 回调接入项目日志系统。
    /// </summary>
    public class CheckUpdate
    {
        private readonly string _serverUrl;
        private readonly string _targetFolder;

        /// <summary>日志回调（默认 Console.WriteLine）</summary>
        public static Action<string> Log = msg => Console.WriteLine($"[CheckUpdate] {msg}");

        public CheckUpdate(string serverUrl)
        {
            _serverUrl = serverUrl.TrimEnd('/');
            _targetFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
            Log?.Invoke($"初始化: target={_targetFolder}");
        }

        public async Task ExecuteAsync()
        {
            Log?.Invoke("开始更新...");
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                // 1. 获取文件列表
                Log?.Invoke($"GET {_serverUrl}/files");
                string filesJson = await client.GetStringAsync($"{_serverUrl}/files");
                List<FileEntry> serverFiles = JsonConvert.DeserializeObject<List<FileEntry>>(filesJson) ?? new List<FileEntry>();
                Log?.Invoke($"服务器文件数: {serverFiles.Count}");

                // 3. 下载到暂存目录 _update（避免运行中文件被锁）
                string stageDir = Path.Combine(_targetFolder, "_update");
                try { if (Directory.Exists(stageDir)) Directory.Delete(stageDir, true); }
                catch (Exception ex) { Log?.Invoke($"清理旧暂存失败: {ex.Message}"); }
                Directory.CreateDirectory(stageDir);
                Log?.Invoke($"暂存目录: {stageDir}");

                var sw = Stopwatch.StartNew();
                long totalBytes = 0;
                int ok = 0, fail = 0;
                foreach (var file in serverFiles)
                {
                    string localPath = Path.Combine(stageDir, file.Path.Replace('/', Path.DirectorySeparatorChar));
                    string dir = Path.GetDirectoryName(localPath);
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    try
                    {
                        Log($"  下载: {file.Path} ({file.Size} bytes)");
                        byte[] data = await client.GetByteArrayAsync(
                            $"{_serverUrl}/file?path={Uri.EscapeDataString(file.Path)}");
                        File.WriteAllBytes(localPath, data);
                        totalBytes += file.Size;
                        ok++;
                    }
                    catch (Exception ex)
                    {
                        Log($"  失败: {file.Path} — {ex.Message}");
                        fail++;
                    }
                }
                sw.Stop();
                double speed = totalBytes / 1024.0 / 1024.0 / (sw.Elapsed.TotalSeconds > 0 ? sw.Elapsed.TotalSeconds : 1);
                Log?.Invoke($"下载完成: 成功 {ok}, 失败 {fail}, {totalBytes / (1024.0 * 1024.0):F1} MB, 用时 {sw.Elapsed.TotalSeconds:F1}s, 速度 {speed:F1} MB/s");

                if (ok == 0)
                {
                    Log?.Invoke("没有成功下载任何文件，取消更新");
                    return;
                }

                // 4. 生成替换批处理 → 退出 → 批处理覆盖 + 重启
                string exeName = Process.GetCurrentProcess().MainModule.FileName;
                string batchPath = Path.Combine(_targetFolder, "_update.bat");
                string xcopyCmd = $"xcopy /Y /E \"{stageDir}\\*\" \"{_targetFolder}\\\" >nul\r\n";
                File.WriteAllText(batchPath,
                    "@echo off\r\n" +
                    "timeout /t 2 /nobreak >nul\r\n" +
                    xcopyCmd +
                    $"start \"\" \"{exeName}\"\r\n" +
                    $"rmdir /S /Q \"{stageDir}\"\r\n" +
                    "del \"%~f0\"\r\n",
                    Encoding.Default);
                Log?.Invoke($"批处理已生成: {batchPath}");

                try
                {
                    Process.Start(new ProcessStartInfo("cmd.exe", $"/c \"{batchPath}\"")
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    });
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Log?.Invoke($"启动批处理失败: {ex.Message}, 尝试直接重启");
                    try { Process.Start(exeName); } catch { }
                    Environment.Exit(0);
                }
            }
        }

    }

    public class FileEntry
    {
        public string Path { get; set; }
        public long Size { get; set; }
    }
}
