using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Update.Common.Update;

namespace Update
{
    internal class Program
    {
        static object consoleLock = new object();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // --help
            if (args.Length >= 1 && (args[0] == "--help" || args[0] == "-h"))
            {
                Console.WriteLine("Update.exe — HTTP 更新服务端");
                Console.WriteLine();
                Console.WriteLine("用法:");
                Console.WriteLine("  Update.exe [文件夹] [端口]");
                Console.WriteLine("  Update.exe --help");
                Console.WriteLine();
                Console.WriteLine("示例:");
                Console.WriteLine("  Update.exe                      当前目录, 端口 12222");
                Console.WriteLine("  Update.exe \"D:\\Release\" 12222   指定目录和端口");
                Console.WriteLine();
                Console.WriteLine("启动后输入 help 查看服务端命令");
                return;
            }

            string folder = args.Length >= 1 ? args[0] : null; // null 则由 UpdateServer 默认取 exe目录/update
            int port = 12222;
            if (args.Length >= 2) int.TryParse(args[1], out port);

            RunServer(folder, port);
        }

        static void RunServer(string folder, int port)
        {
            int tcpPort = port + 1;
            Console.Title = $"Update Server — HTTP:{port} TCP:{tcpPort}";
            LogInfo("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            LogInfo("  HTTP 文件服务 + TCP 命令通道");
            LogInfo("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            UpdateServer server = null;
            try
            {
                server = new UpdateServer(folder, port);
                server.UpdateLog = (time, msg) =>
                {
                    lock (consoleLock)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"[{time:HH:mm:ss}] {msg}");
                        Console.ResetColor();
                    }
                };

                // 启动摘要
                LogInfo($"更新目录: {server.UpdateFolderPath}");
                string[] files = server.GetTopFiles();
                if (files.Length > 0)
                {
                    LogInfo($"目录内容 ({files.Length} 个文件):");
                    foreach (var f in files)
                        Console.WriteLine($"    {Path.GetFileName(f)}");
                }
                else
                {
                    LogWarn("更新目录为空，请放入更新文件");
                }
                Console.WriteLine();
                LogInfo("输入 help 查看所有命令");

                bool running = true;
                var inputThread = new Thread(() =>
                {
                    while (running)
                    {
                        string line = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        switch (line.Trim().ToLower())
                        {
                            case "help":
                            case "h":
                            case "?":
                                PrintHelp();
                                break;
                            case "notify":
                                server.NotifyUpdate();
                                break;
                            case "force":
                                server.ForceUpdate();
                                break;
                            case "list":
                                PrintClientList(server);
                                break;
                            case "q":
                            case "quit":
                            case "exit":
                                running = false;
                                break;
                            default:
                                LogWarn($"未知命令: {line}  (输入 help 查看可用命令)");
                                break;
                        }
                    }
                })
                { IsBackground = true };
                inputThread.Start();

                while (running) { Thread.Sleep(200); }
            }
            catch (Exception ex)
            {
                LogError($"服务端启动失败: {ex.Message}");
                LogWarn("可能需要管理员权限注册 HTTP 监听:");
                LogWarn($"  netsh http add urlacl url=http://+:{port}/ user=Everyone");
                Console.ReadKey();
            }
            finally
            {
                server?.Stop();
                LogInfo("服务端已停止");
            }
        }

        static void PrintClientList(UpdateServer server)
        {
            lock (consoleLock)
            {
                var clients = server.Clients;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"── 客户端列表 (共 {clients.Count}) ──");
                if (clients.Count == 0)
                {
                    Console.WriteLine("  (无连接)");
                }
                else
                {
                    foreach (var c in clients)
                    {
                        bool active = (DateTime.Now - c.LastActivity).TotalSeconds < 30;
                        string icon = active ? "●" : "○";
                        Console.WriteLine($"  {icon} {c.IP,-18} {c.Status,-12} 文件:{c.FilesDownloaded}");
                    }
                    Console.WriteLine($"  TCP 连接数: {server.TcpClientCount}");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        static void PrintHelp()
        {
            lock (consoleLock)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("  可用命令");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("  notify  — 通知所有在线客户端更新");
                Console.WriteLine("  force   — 强制所有在线客户端立即更新");
                Console.WriteLine("  list    — 查看客户端连接状态");
                Console.WriteLine("  help    — 显示此帮助");
                Console.WriteLine("  q       — 退出服务端");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        static void LogInfo(string message)
        {
            lock (consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[INFO] {message}");
                Console.ResetColor();
            }
        }

        static void LogError(string message)
        {
            lock (consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] {message}");
                Console.ResetColor();
            }
        }

        static void LogWarn(string message)
        {
            lock (consoleLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARN] {message}");
                Console.ResetColor();
            }
        }
    }

}
