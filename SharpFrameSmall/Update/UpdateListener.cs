using System;
using System.Threading.Tasks;
using System.Windows;

namespace SharpFrameSmall.Update
{
    /// <summary>
    /// 客户端后台更新监听器 — TCP 收命令，触发 HTTP 下载。
    /// </summary>
    public class UpdateListener
    {
        private readonly string _serverUrl;
        private readonly string _serverIP;
        private readonly int _tcpPort;
        private UpdateTcpClient _tcp;
        private bool _updating;

        /// <summary>日志回调（按需注入）</summary>
        public static Action<string> Log;

        public UpdateListener(string serverUrl)
        {
            _serverUrl = serverUrl.TrimEnd('/');
            _serverIP = ExtractHost(serverUrl);
            _tcpPort = ExtractPort(serverUrl) + 1;
        }

        public void Start()
        {
            if (_tcp != null) return;
            _tcp = new UpdateTcpClient(_serverIP, _tcpPort);
            _tcp.OnNotify += version =>
                Application.Current.Dispatcher.BeginInvoke(new Action(() => OnNotifyCommand(version)));
            _tcp.OnForce += version =>
                Application.Current.Dispatcher.BeginInvoke(new Action(() => OnForceCommand(version)));
            _tcp.Start();
        }

        public void Stop() => _tcp?.Stop();

        private void OnNotifyCommand(string _)
        {
            if (_updating) return;
            Log?.Invoke("[Update] 收到通知更新");
            ExecuteUpdate();
        }

        private void OnForceCommand(string _)
        {
            if (_updating) return;
            Log?.Invoke("[Update] 收到强制更新");
            ExecuteUpdate();
        }

        private async void ExecuteUpdate()
        {
            if (_updating) return;
            _updating = true;

            try
            {
                await Task.Run(async () =>
                {
                    await new CheckUpdate(_serverUrl).ExecuteAsync();
                });
            }
            catch (Exception ex)
            {
                Log?.Invoke($"[Update] 更新异常: {ex.Message}");
            }
            finally
            {
                _updating = false;
            }
        }

        private static string ExtractHost(string url)
        {
            try
            {
                string s = url.Replace("http://", "").Replace("https://", "");
                int colon = s.LastIndexOf(':');
                return colon > 0 ? s.Substring(0, colon) : s.TrimEnd('/');
            }
            catch { return "127.0.0.1"; }
        }

        private static int ExtractPort(string url)
        {
            try
            {
                int colon = url.LastIndexOf(':');
                if (colon > 0 && int.TryParse(url.Substring(colon + 1).TrimEnd('/'), out int p))
                    return p;
            }
            catch { }
            return 12222;
        }
    }
}
