using Newtonsoft.Json.Linq;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpFrameSmall.Update
{
    /// <summary>
    /// 更新命令 TCP 客户端 — 连接服务端 TCP 命令通道，
    /// 接收 notify / force 推送，断线自动重连。
    /// </summary>
    public class UpdateTcpClient
    {
        private readonly string _serverIP;
        private readonly int _port;
        private TcpClient _tcp;
        private NetworkStream _stream;
        private byte[] _buffer = new byte[4096];
        private StringBuilder _lineBuffer = new StringBuilder();
        private CancellationTokenSource _cts;
        private bool _running;

        public event Action<string> OnNotify;
        public event Action<string> OnForce;
        public event Action<bool> OnConnected;

        public bool IsConnected => _tcp != null && _tcp.Connected;

        public UpdateTcpClient(string serverIP, int port = 12223)
        {
            _serverIP = serverIP;
            _port = port;
        }

        public void Start()
        {
            if (_running) return;
            _running = true;
            _cts = new CancellationTokenSource();
            Task.Run(() => RunLoop(_cts.Token));
        }

        public void Stop()
        {
            _running = false;
            _cts?.Cancel();
            Disconnect();
        }

        private async Task RunLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    Connect();
                    await ReadLoop(ct);
                }
                catch { }
                try { await Task.Delay(5000, ct); } catch { break; }
            }
        }

        private void Connect()
        {
            Disconnect();
            _tcp = new TcpClient();
            _tcp.Connect(_serverIP, _port);
            _stream = _tcp.GetStream();
            _lineBuffer.Clear();
            OnConnected?.Invoke(true);
        }

        private async Task ReadLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested && IsConnected)
            {
                int len = await _stream.ReadAsync(_buffer, 0, _buffer.Length, ct);
                if (len == 0) break;

                string chunk = Encoding.UTF8.GetString(_buffer, 0, len);
                _lineBuffer.Append(chunk);

                while (true)
                {
                    string buf = _lineBuffer.ToString();
                    int nl = buf.IndexOf('\n');
                    if (nl < 0) break;

                    string line = buf.Substring(0, nl).Trim();
                    _lineBuffer.Remove(0, nl + 1);
                    if (!string.IsNullOrEmpty(line))
                        ProcessLine(line);
                }
            }
            Disconnect();
        }

        private void ProcessLine(string json)
        {
            try
            {
                var obj = JObject.Parse(json);
                string cmd = obj["cmd"]?.Value<string>() ?? "";

                if (cmd == "notify")
                    OnNotify?.Invoke("");
                else if (cmd == "force")
                    OnForce?.Invoke("");
            }
            catch { }
        }

        private void Disconnect()
        {
            OnConnected?.Invoke(false);
            try { _stream?.Close(); } catch { }
            try { _tcp?.Close(); } catch { }
            _stream = null;
            _tcp = null;
        }
    }
}
