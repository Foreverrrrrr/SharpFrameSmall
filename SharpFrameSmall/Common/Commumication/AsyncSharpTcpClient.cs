using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpFrameSmall.Common.Commumication
{
    /// <summary>
    /// TCP/IP 异步客户端
    /// </summary>
    public class AsyncSharpTcpClient : IDisposable
    {
        private const int DefaultConnectionTimeoutMs = 3000;
        private const int DefaultReconnectDelayMs = 3000;
        private const int DefaultSendReceiveTimeoutMs = 5000;
        private const int DefaultReadBufferSize = 1024 * 1024;
        private const uint DefaultKeepAliveTimeMs = 60000;
        private const uint DefaultKeepAliveIntervalMs = 10000;

        private static readonly Encoding DefaultEncoding = Encoding.ASCII;

        /// <summary>服务器 IP 地址</summary>
        public string Target_IP { get; private set; }

        /// <summary>服务器端口号</summary>
        public int Target_Port { get; private set; }

        /// <summary>是否已连接</summary>
        public bool IsConnect { get; private set; }

        /// <summary>当前异步读取句柄</summary>
        public IAsyncResult Connect_Read { get; private set; }

        /// <summary>最近一次接收到的文本</summary>
        public string AsynRead { get; private set; }

        /// <summary>连接超时时，默认 3000ms</summary>
        public int ConnectionTimeoutMs { get; set; } = DefaultConnectionTimeoutMs;

        /// <summary>重连延迟时间，默认 3000ms</summary>
        public int ReconnectDelayMs { get; set; } = DefaultReconnectDelayMs;

        /// <summary>同步收发超时时间，默认 5000ms</summary>
        public int SendReceiveTimeoutMs { get; set; } = DefaultSendReceiveTimeoutMs;

        /// <summary>数据接收事件</summary>
        public event Action<DateTime, IPEndPoint, string> ReceiveEvent;

        /// <summary>连接断开事件</summary>
        public event Action<DateTime, Exception> DisconnectionEvent;

        /// <summary>连接成功事件</summary>
        public event Action<DateTime, IPEndPoint> SuccessfuConnectEvent;

        private TcpClient _tcpClient;
        private object _connectionToken = new object();
        private CancellationTokenSource _closeCts = new CancellationTokenSource();
        private TaskCompletionSource<string> _receiveWaiter;

        private byte[] _readBuffer = new byte[DefaultReadBufferSize];

        private volatile bool _isClosed;
        private volatile bool _isReconnecting;
        private volatile bool _suppressDisconnectEvent = true;
        private volatile bool _isDisposed;

        public AsyncSharpTcpClient() { }

        /// <summary>创建客户端并连接到指定服务器</summary>
        public AsyncSharpTcpClient(string targetip, int targetport)
        {
            AsyncNewTcp(targetip, targetport);
        }

        /// <summary>
        /// 连接到 TCP 服务器。若已有连接则自动切换，并触发旧连接的断开事件。
        /// </summary>
        public void AsyncNewTcp(string targetip, int targetport)
        {
            if (_isDisposed) throw new ObjectDisposedException(nameof(AsyncSharpTcpClient));
            _isClosed = false;

            bool wasConnected = IsConnect && _tcpClient != null && _tcpClient.Connected;
            IPAddress oldIP = null;
            if (wasConnected)
            {
                try { oldIP = IPAddress.Parse(Target_IP); } catch { }
            }
            Target_IP = targetip;
            Target_Port = targetport;
            try
            {
                _connectionToken = new object();
                CloseExistingClient();
                if (wasConnected)
                {
                    RaiseDisconnectionEvent(new Exception(
                        $"主动断开与服务器 {oldIP} 的连接，准备连接新服务器"));
                }
                Connect_Read = null;
                CancelPendingWaiter();
                _tcpClient = new TcpClient();
                ConfigureKeepAlive(_tcpClient);
                _tcpClient.BeginConnect(IPAddress.Parse(Target_IP), Target_Port,
                    new AsyncCallback(AsyncConnect), _connectionToken);
            }
            catch (Exception ex)
            {
                IsConnect = false;
                RaiseDisconnectionEvent(ex);
            }
        }

        /// <summary>
        /// 关闭连接并停止自动重连。可再次调用 <see cref="AsyncNewTcp"/> 重新连接。
        /// </summary>
        public void Close()
        {
            try
            {
                _isClosed = true;
                _closeCts.Cancel();
                _suppressDisconnectEvent = true;

                bool wasConnected = IsConnect && _tcpClient != null && _tcpClient.Connected;
                string currentIP = Target_IP;
                IsConnect = false;

                _connectionToken = new object();
                CloseExistingClient();
                Connect_Read = null;
                AsynRead = null;
                CancelPendingWaiter();

                if (wasConnected)
                {
                    RaiseDisconnectionEvent(new Exception(
                        $"主动关闭与服务器 {currentIP} 的连接"));
                }

                _closeCts = new CancellationTokenSource();
            }
            catch (Exception ex)
            {
                RaiseDisconnectionEvent(ex);
            }
        }

        /// <summary>异步发送</summary>
        public void SendMessage(string msg, Encoding encoding)
        {
            try
            {
                if (_tcpClient == null || !_tcpClient.Connected || _tcpClient.GetStream() == null)
                {
                    RaiseDisconnectionEvent(new Exception("连接已断开，无法发送消息"));
                    return;
                }

                byte[] msgBytes = encoding.GetBytes(msg);
                _tcpClient.GetStream().BeginWrite(msgBytes, 0, msgBytes.Length, ar =>
                {
                    try { _tcpClient?.GetStream()?.EndWrite(ar); }
                    catch (SocketException ex)    { RaiseDisconnectionEvent(ex); IsConnect = false; SafeCleanupAndReconnect(); }
                    catch (IOException ex)        { RaiseDisconnectionEvent(ex); IsConnect = false; SafeCleanupAndReconnect(); }
                    catch (Exception ex)          { RaiseDisconnectionEvent(ex); }
                }, null);
            }
            catch (Exception ex)
            {
                RaiseDisconnectionEvent(ex);
                IsConnect = false;
                SafeCleanupAndReconnect();
            }
        }

        /// <summary>异步发送</summary>
        public void SendMessage(string msg) => SendMessage(msg, DefaultEncoding);

        /// <summary>发送并同步等待响应</summary>
        public string SyncSendReceive(string msg, Encoding encoding)
        {
            try { return SyncSendReceiveCore(msg, encoding); }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                RaiseDisconnectionEvent(ex);
                IsConnect = false;
                SafeCleanupAndReconnect();
            }
            return AsynRead;
        }

        /// <summary>发送并同步等待响应</summary>
        public string SyncSendReceive(string msg) => SyncSendReceive(msg, DefaultEncoding);

        /// <summary>发送并校验响应</summary>
        public bool SyncSendReceive(string msg, string read_msg, Encoding encoding)
        {
            try
            {
                string result = SyncSendReceiveCore(msg, encoding);
                return result != null && read_msg == result.Trim('\r', '\n');
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                RaiseDisconnectionEvent(ex);
                IsConnect = false;
                SafeCleanupAndReconnect();
            }
            return false;
        }

        /// <summary>发送并校验响应</summary>
        public bool SyncSendReceive(string msg, string read_msg) =>
            SyncSendReceive(msg, read_msg, DefaultEncoding);

        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;
            Close();
            _closeCts.Dispose();
            GC.SuppressFinalize(this);
        }

        private void AsyncConnect(IAsyncResult async)
        {
            if (async.AsyncState != _connectionToken)
                return;

            try
            {
                if (!async.AsyncWaitHandle.WaitOne(ConnectionTimeoutMs))
                {
                    try { _tcpClient?.EndConnect(async); } catch { }
                    IsConnect = false;
                    CloseExistingClient();
                    if (!_isClosed) DelayedReconnect();
                    return;
                }
                if (async.AsyncState != _connectionToken || _tcpClient == null)
                {
                    IsConnect = false;
                    return;
                }
                _tcpClient.EndConnect(async);
                if (!_tcpClient.Connected)
                {
                    IsConnect = false;
                    CloseExistingClient();
                    if (!_isClosed) DelayedReconnect();
                    return;
                }
                IsConnect = true;
                _suppressDisconnectEvent = false;
                try
                {
                    var ep = new IPEndPoint(IPAddress.Parse(Target_IP), Target_Port);
                    SuccessfuConnectEvent?.Invoke(DateTime.Now, ep);
                }
                catch { }
                Connect_Read = _tcpClient.GetStream().BeginRead(
                    _readBuffer, 0, _readBuffer.Length, new AsyncCallback(AsyncRead), _connectionToken);
            }
            catch (Exception ex)
            {
                IsConnect = false;
                if (!_suppressDisconnectEvent)
                    RaiseDisconnectionEvent(ex);
                CloseExistingClient();
                if (!_isClosed) DelayedReconnect();
            }
        }

        private void AsyncRead(IAsyncResult async)
        {
            if (async.AsyncState != _connectionToken)
                return;
            try
            {
                if (async.AsyncState != _connectionToken || _tcpClient == null || _tcpClient.GetStream() == null)
                {
                    IsConnect = false;
                    return;
                }
                int len = _tcpClient.GetStream().EndRead(async);
                if (len > 0)
                {
                    IsConnect = true;
                    string raw = DefaultEncoding.GetString(_readBuffer, 0, len);
                    AsynRead = Uri.UnescapeDataString(raw);
                    var eventEp = new IPEndPoint(IPAddress.Parse(Target_IP), Target_Port);
                    Task.Run(() =>
                    {
                        try { ReceiveEvent?.Invoke(DateTime.Now, eventEp, raw); } catch { }
                    });
                    var waiter = Interlocked.Exchange(ref _receiveWaiter, null);
                    waiter?.TrySetResult(AsynRead);
                    if (_connectionToken == async.AsyncState && _tcpClient != null && _tcpClient.Connected)
                    {
                        Connect_Read = _tcpClient.GetStream().BeginRead(
                            _readBuffer, 0, _readBuffer.Length, new AsyncCallback(AsyncRead), _connectionToken);
                    }
                }
                else
                {
                    IsConnect = false;
                    RaiseDisconnectionEvent(new Exception("监测到服务器关闭"));
                    SafeCleanupAndReconnect();
                }
            }
            catch (ObjectDisposedException)
            {
                IsConnect = false;
            }
            catch (Exception ex)
            {
                RaiseDisconnectionEvent(ex);
                IsConnect = false;
                SafeCleanupAndReconnect();
            }
        }

        private string SyncSendReceiveCore(string msg, Encoding encoding)
        {
            if (_tcpClient == null || !_tcpClient.Connected || _tcpClient.GetStream() == null)
                return null;
            var waiter = new TaskCompletionSource<string>();
            _receiveWaiter = waiter;
            AsynRead = null;
            byte[] msgBytes = encoding.GetBytes(msg);
            _tcpClient.GetStream().BeginWrite(msgBytes, 0, msgBytes.Length, ar =>
            {
                try { _tcpClient?.GetStream()?.EndWrite(ar); }
                catch (Exception ex) { waiter.TrySetException(ex); }
            }, null);
            if (!waiter.Task.Wait(SendReceiveTimeoutMs, _closeCts.Token))
            {
                Interlocked.CompareExchange(ref _receiveWaiter, null, waiter);
                return null;
            }
            return waiter.Task.Result;
        }

        private void CloseExistingClient()
        {
            if (_tcpClient == null) return;
            try
            {
                IsConnect = false;
                _tcpClient.Close();
            }
            catch { }
            finally
            {
                _tcpClient = null;
            }
        }

        private void CancelPendingWaiter()
        {
            Interlocked.Exchange(ref _receiveWaiter, null)?.TrySetCanceled();
        }

        private void SafeCleanupAndReconnect(bool shouldReconnect = true)
        {
            _connectionToken = new object();
            CloseExistingClient();
            Connect_Read = null;
            CancelPendingWaiter();
            if (shouldReconnect && !_isClosed && !string.IsNullOrEmpty(Target_IP) && Target_Port > 0)
            {
                DelayedReconnect();
            }
        }

        private void DelayedReconnect()
        {
            if (_isReconnecting || _isClosed) return;
            _isReconnecting = true;
            _suppressDisconnectEvent = true;
            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(ReconnectDelayMs).ConfigureAwait(false);
                    if (!_isClosed)
                        AsyncNewTcp(Target_IP, Target_Port);
                }
                finally
                {
                    _isReconnecting = false;
                }
            });
        }

        private void RaiseDisconnectionEvent(Exception ex)
        {
            try { DisconnectionEvent?.Invoke(DateTime.Now, ex); } catch { }
        }

        private static void ConfigureKeepAlive(TcpClient client, uint keepAliveTimeMs = DefaultKeepAliveTimeMs, uint keepAliveIntervalMs = DefaultKeepAliveIntervalMs)
        {
            try
            {
                if (client?.Client == null) return;
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                byte[] inValues = new byte[12];
                BitConverter.GetBytes((uint)1).CopyTo(inValues, 0);
                BitConverter.GetBytes(keepAliveTimeMs).CopyTo(inValues, 4);
                BitConverter.GetBytes(keepAliveIntervalMs).CopyTo(inValues, 8);
                byte[] outValues = new byte[4];
                client.Client.IOControl(IOControlCode.KeepAliveValues, inValues, outValues);
            }
            catch { }
        }
    }
}
