using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Update.Common.Update
{
    /// <summary>
    /// HTTP 更新服务端 — HTTP 提供文件下载，TCP 提供命令推送通道。
    /// TCP 端口 = HTTP 端口 + 1（如 HTTP 12222 → TCP 12223）。
    /// 协议：JSON 行（\n 结尾）。
    /// </summary>
    public class UpdateServer
    {
        private HttpListener _http;
        private TcpListener _tcp;
        private string updateFolder;
        private int _httpPort;

        public Action<DateTime, string> UpdateLog;

        // ──── TCP 客户端 ────
        private readonly object _tcpLock = new object();
        private readonly List<TcpClient> _tcpClients = new List<TcpClient>();
        private bool _tcpRunning;

        // ──── 客户端追踪 ────
        private readonly object _clientLock = new object();
        private readonly Dictionary<string, ClientRecord> _clients = new Dictionary<string, ClientRecord>();

        public string UpdateFolderPath => updateFolder;
        public int TcpClientCount { get { lock (_tcpLock) return _tcpClients.Count; } }
        public List<ClientRecord> Clients
        {
            get
            {
                lock (_clientLock)
                {
                    var cutoff = DateTime.Now.AddMinutes(-2);
                    var stale = _clients.Where(kv => kv.Value.LastActivity < cutoff).Select(kv => kv.Key).ToList();
                    foreach (var key in stale) _clients.Remove(key);
                    return _clients.Values.ToList();
                }
            }
        }

        public UpdateServer(string folder = null, int httpPort = 12222)
        {
            this._httpPort = httpPort;
            this.updateFolder = folder ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update");

            // ── 启动 HTTP ──
            try
            {
                _http = new HttpListener();
                _http.Prefixes.Add($"http://+:{httpPort}/");
                _http.Start();
                _http.BeginGetContext(OnHttpRequest, null);
                Log($"HTTP 文件服务已启动, 端口 {httpPort}");
            }
            catch (HttpListenerException ex)
            {
                Log($"HTTP 启动失败 (端口 {httpPort}): {ex.Message}");
                throw;
            }

            // ── 启动 TCP ──
            int tcpPort = httpPort + 1;
            try
            {
                _tcp = new TcpListener(IPAddress.Any, tcpPort);
                _tcp.Start();
                _tcpRunning = true;
                _tcp.BeginAcceptTcpClient(OnTcpAccept, null);
                Log($"TCP 命令通道已启动, 端口 {tcpPort}");
            }
            catch (Exception ex)
            {
                Log($"TCP 启动失败 (端口 {tcpPort}): {ex.Message}");
            }
        }

        public void Stop()
        {
            _tcpRunning = false;
            _tcp?.Stop();
            lock (_tcpLock) { foreach (var c in _tcpClients) { try { c.Close(); } catch { } } _tcpClients.Clear(); }
            if (_http?.IsListening == true) { _http.Stop(); _http.Close(); }
            Log("服务器已停止");
        }

        // ════ 公开命令 ════

        public void NotifyUpdate()  => BroadcastTcp("notify");
        public void ForceUpdate()   => BroadcastTcp("force");

        public string[] GetTopFiles()
        {
            if (!Directory.Exists(updateFolder)) return new string[0];
            return Directory.GetFiles(updateFolder);
        }

        // ════ TCP 通道 ════

        private void OnTcpAccept(IAsyncResult ar)
        {
            if (!_tcpRunning) return;
            TcpClient client;
            try { client = _tcp.EndAcceptTcpClient(ar); }
            catch { return; }
            _tcp.BeginAcceptTcpClient(OnTcpAccept, null);

            string ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            lock (_tcpLock) { _tcpClients.Add(client); }
            TrackClient(ip, "tcp_connect", "在线");
            Log($"[{ip}] TCP 客户端已连接 (共 {TcpClientCount})");

            // 启动异步读取（保持连接活跃，检测断开）
            var buffer = new byte[1024];
            try { client.GetStream().BeginRead(buffer, 0, buffer.Length, OnTcpRead, new TcpState { Client = client, Buffer = buffer, IP = ip }); }
            catch { RemoveTcpClient(client, ip); }
        }

        private void OnTcpRead(IAsyncResult ar)
        {
            var state = (TcpState)ar.AsyncState;
            try
            {
                int len = state.Client.GetStream().EndRead(ar);
                if (len == 0) { RemoveTcpClient(state.Client, state.IP); return; }
                // 继续读取保持连接
                state.Client.GetStream().BeginRead(state.Buffer, 0, state.Buffer.Length, OnTcpRead, state);
            }
            catch { RemoveTcpClient(state.Client, state.IP); }
        }

        private void BroadcastTcp(string cmd)
        {
            string json = JsonConvert.SerializeObject(new { cmd }) + "\n";
            byte[] data = Encoding.UTF8.GetBytes(json);

            Log($">>> 操作员: {cmd} → 广播到 {TcpClientCount} 个客户端");

            List<TcpClient> batch;
            lock (_tcpLock) { batch = new List<TcpClient>(_tcpClients); }

            foreach (var c in batch)
            {
                try { c.GetStream().Write(data, 0, data.Length); }
                catch { RemoveTcpClient(c, null); }
            }
        }

        private void RemoveTcpClient(TcpClient client, string ip)
        {
            lock (_tcpLock) { _tcpClients.Remove(client); }
            try { client.Close(); } catch { }
            if (!string.IsNullOrEmpty(ip))
            {
                TrackClient(ip, "tcp_disconnect", "离线");
                Log($"[{ip}] TCP 客户端断开 (共 {TcpClientCount})");
            }
        }

        // ════ HTTP 路由 ════

        private void OnHttpRequest(IAsyncResult ar)
        {
            if (!_http.IsListening) return;
            HttpListenerContext ctx;
            try { ctx = _http.EndGetContext(ar); } catch { return; }
            _http.BeginGetContext(OnHttpRequest, null);

            var req = ctx.Request; var res = ctx.Response;
            string path = req.RawUrl.Split('?')[0].ToLowerInvariant().TrimStart('/');
            var query = req.QueryString;
            string ip = req.RemoteEndPoint?.Address?.ToString() ?? "?";

            if (path == "version" || path == "files")
                Log($"[{ip}] HTTP {path}");

            try
            {
                switch (path)
                {
                    case "files": HandleFileList(res); break;
                    case "file":  HandleFileDownload(res, query["path"], ip); break;
                    default:
                        res.StatusCode = 404; WriteText(res, "Not Found"); res.Close(); break;
                }
            }
            catch (Exception ex)
            {
                Log($"异常: {ex.Message}");
                try { res.StatusCode = 500; WriteText(res, ex.Message); res.Close(); } catch { }
            }
        }

        // ════ 客户端追踪 ════

        private void TrackClient(string ip, string action, string status)
        {
            lock (_clientLock)
            {
                if (!_clients.TryGetValue(ip, out var cr))
                {
                    cr = new ClientRecord { IP = ip, FirstSeen = DateTime.Now };
                    _clients[ip] = cr;
                }
                cr.LastActivity = DateTime.Now;
                cr.LastAction = action;
                cr.Status = status;
                if (action == "file") cr.FilesDownloaded++;
            }
        }

        // ════ HTTP 接口 ════

        private void HandleFileList(HttpListenerResponse res)
        {
            if (!Directory.Exists(updateFolder))
            { res.StatusCode = 500; WriteText(res, "Update folder not found"); res.Close(); return; }
            var list = new List<FileEntry>();
            CollectFiles(updateFolder, updateFolder, list);
            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(list, Formatting.Indented));
            res.ContentType = "application/json; charset=utf-8";
            res.ContentLength64 = data.Length;
            res.OutputStream.Write(data, 0, data.Length);
            res.OutputStream.Close(); res.Close();
        }

        private void CollectFiles(string root, string current, List<FileEntry> result)
        {
            foreach (var f in Directory.GetFiles(current))
                result.Add(new FileEntry { Path = GetRelPath(root, f), Size = new FileInfo(f).Length });
            foreach (var d in Directory.GetDirectories(current))
            {
                string dn = Path.GetFileName(d);
                if (dn == "Logs" || dn == "log" || dn == "Update" || dn == "Config") continue;
                CollectFiles(root, d, result);
            }
        }

        private string GetRelPath(string root, string full)
            => full.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Replace('\\', '/');

        private void HandleFileDownload(HttpListenerResponse res, string relativePath, string ip)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            { res.StatusCode = 400; WriteText(res, "Missing 'path'"); res.Close(); return; }
            relativePath = relativePath.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar).TrimStart(Path.DirectorySeparatorChar);
            string full = Path.GetFullPath(Path.Combine(updateFolder, relativePath));
            if (!full.StartsWith(Path.GetFullPath(updateFolder), StringComparison.OrdinalIgnoreCase))
            { res.StatusCode = 403; WriteText(res, "Forbidden"); res.Close(); return; }
            if (!File.Exists(full))
            { res.StatusCode = 404; WriteText(res, "File not found"); res.Close(); return; }

            TrackClient(ip, "file", "下载中");
            res.ContentType = "application/octet-stream";
            using (FileStream fs = new FileStream(full, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                res.ContentLength64 = fs.Length;
                byte[] buf = new byte[5 * 1024 * 1024];
                int n;
                while ((n = fs.Read(buf, 0, buf.Length)) > 0)
                { res.OutputStream.Write(buf, 0, n); res.OutputStream.Flush(); }
            }
            res.OutputStream.Close(); res.Close();
        }

        // ════ 工具 ════

        private void WriteText(HttpListenerResponse r, string s)
        { byte[] d = Encoding.UTF8.GetBytes(s); r.ContentLength64 = d.Length; r.OutputStream.Write(d, 0, d.Length); r.OutputStream.Close(); }

        private void Log(string msg) => UpdateLog?.Invoke(DateTime.Now, msg);

        // ════ 内部类 ════

        private class TcpState
        {
            public TcpClient Client;
            public byte[] Buffer;
            public string IP;
        }
    }

    public class ClientRecord
    {
        public string IP { get; set; }
        public string Status { get; set; } = "在线";
        public string LastAction { get; set; }
        public DateTime FirstSeen { get; set; }
        public DateTime LastActivity { get; set; }
        public int FilesDownloaded { get; set; }
    }

    public class FileEntry
    {
        public string Path { get; set; }
        public long Size { get; set; }
    }
}
