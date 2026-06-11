using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SharpFrameSmall.Common.Commumication
{
    /// <summary>
    /// TCP\ip服务器
    /// </summary>
    public class AsyncSharpTcpServer
    {
        /// <summary>
        /// 数据接收事件
        /// </summary>
        public event Action<DateTime, IPEndPoint, string> OnTCPReadEvent;

        /// <summary>
        /// 客户端断开事件
        /// </summary>
        public event Action<DateTime, Exception> DisconnectionEvent;

        /// <summary>
        /// 客户端连接事件
        /// </summary>
        public event Action<DateTime, IPEndPoint> SuccessfuConnectEvent;

        private object lockObject = new object();

        private Socket socketCore = null;

        private byte[] _buffer = new byte[1024 * 4];

        /// <summary>
        /// 接收缓存区大小
        /// </summary>
        public byte[] buffer
        {
            get { return _buffer; }
            set { _buffer = value; }
        }

        /// <summary>
        /// 客户端连接队列
        /// </summary>
        private List<ClientSession> sockets = new List<ClientSession>();

        private volatile bool _isconnet = false;
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsCommet
        {
            get { return _isconnet; }
            set { _isconnet = value; }
        }

        public AsyncSharpTcpServer()
        {
                
        }
        /// <summary>
        /// 打开服务器
        /// </summary>
        /// <param name="ip">服务器IP</param>
        /// <param name="port">服务器端口号</param>
        public AsyncSharpTcpServer(string ip, int port)
        {
            try
            {
                IPAddress pcip = IPAddress.Parse(ip);
                socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketCore.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socketCore.Bind(new IPEndPoint(pcip, port));
                socketCore.Listen(1024);
                _isconnet = true;
                socketCore.BeginAccept(new AsyncCallback(AsyncAcceptCallback), socketCore);
            }
            catch (Exception ex)
            {
                _isconnet = false;
                DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
                throw;
            }
        }

        /// <summary>
        /// 异步传入的连接申请请求
        /// </summary>
        /// <param name="iar">异步对象</param>
        private void AsyncAcceptCallback(IAsyncResult iar)
        {
            if (iar.AsyncState is Socket server_socket)
            {
                Socket client = null;
                ClientSession session = null;
                try
                {
                    client = server_socket.EndAccept(iar);
                    session = new ClientSession();
                    session.Socket = client;
                    session.EndPoint = (IPEndPoint)client.RemoteEndPoint;
                    session.Buffer = new byte[buffer.Length]; 
                    lock (lockObject)
                    {
                        sockets.Add(session);
                    }
                    client.BeginReceive(session.Buffer, 0, session.Buffer.Length, SocketFlags.None, 
                        new AsyncCallback(ReceiveCallBack), session);
                    SuccessfuConnectEvent?.BeginInvoke(DateTime.Now, 
                        new IPEndPoint(session.EndPoint.Address, session.EndPoint.Port), null, null);
                }
                catch (ObjectDisposedException)
                {
                    _isconnet = false;
                    if (session != null)
                    {
                        RemoveClient(session);
                    }
                    return;
                }
                catch (Exception ex)
                {
                    DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
                    if (session != null)
                    {
                        RemoveClient(session);
                    }
                    client?.Close();
                }
                try
                {
                    if (_isconnet)
                    {
                        server_socket.BeginAccept(new AsyncCallback(AsyncAcceptCallback), server_socket);
                    }
                }
                catch (ObjectDisposedException)
                {
                    _isconnet = false;
                }
                catch (Exception ex)
                {
                    DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
                    _isconnet = false;
                }
            }
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            if (ar.AsyncState is ClientSession client)
            {
                try
                {
                    int length = client.Socket.EndReceive(ar);
                    if (length == 0)
                    {
                        DisconnectionEvent?.BeginInvoke(DateTime.Now, 
                            new Exception($"客户端 {client.EndPoint} 断开连接"), null, null);
                        RemoveClient(client);
                        return;
                    }
                    client.Socket.BeginReceive(client.Buffer, 0, client.Buffer.Length, 
                        SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
                    byte[] data = new byte[length];
                    Array.Copy(client.Buffer, 0, data, 0, length);
                    string msg = Encoding.UTF8.GetString(data, 0, length);
                    OnTCPReadEvent?.BeginInvoke(DateTime.Now, 
                        new IPEndPoint(client.EndPoint.Address, client.EndPoint.Port), msg, null, null);
                }
                catch (SocketException ex)
                {
                    DisconnectionEvent?.BeginInvoke(DateTime.Now, 
                        new Exception($"客户端 {client.EndPoint} 网络异常断开: {ex.Message}"), null, null);
                    RemoveClient(client);
                }
                catch (ObjectDisposedException)
                {
                    RemoveClient(client);
                }
                catch (Exception ex)
                {
                    DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
                    RemoveClient(client);
                }
            }
        }

        /// <summary>
        /// 安全移除客户端
        /// </summary>
        /// <param name="client">客户端会话</param>
        private void RemoveClient(ClientSession client)
        {
            if (client == null) return;
            
            try
            {
                if (client.Socket != null)
                {
                    if (client.Socket.Connected)
                    {
                        client.Socket.Shutdown(SocketShutdown.Both);
                    }
                    client.Socket.Close();
                }
            }
            catch { }
            lock (lockObject)
            {
                sockets.Remove(client);
                if (sockets.Count == 0)
                {
                    _isconnet = socketCore != null && socketCore.IsBound;
                }
            }
        }

        /// <summary>
        /// 异步数据发送
        /// </summary>
        /// <param name="ip">客户端ip</param>
        /// <param name="meg">发送字符串</param>
        public void AsyncWrite(string ip, string meg)
        {
            ClientSession targetClient = null;
            lock (lockObject)
            {
                targetClient = sockets.Find(e => e.EndPoint.Address.ToString() == ip);
            }
            if (targetClient != null)
            {
                SendToClient(targetClient, meg);
            }
        }

        /// <summary>
        /// 异步数据发送
        /// </summary>
        /// <param name="ip">客户端ip</param>
        /// <param name="port">客户端端口号</param>
        /// <param name="meg">发送字符串</param>
        public void AsyncWrite(string ip, int port, string meg)
        {
            ClientSession targetClient = null;
            lock (lockObject)
            {
                targetClient = sockets.Find(e => e.EndPoint.Address.ToString() == ip && e.EndPoint.Port == port);
            }
            if (targetClient != null)
            {
                SendToClient(targetClient, meg);
            }
        }

        /// <summary>
        /// 异步数据发送到第一个客户端
        /// </summary>
        /// <param name="meg">发送字符串</param>
        public void AsyncWrite(string meg)
        {
            ClientSession targetClient = null;
            lock (lockObject)
            {
                if (sockets.Count > 0)
                {
                    targetClient = sockets[0];
                }
            }
            if (targetClient != null)
            {
                SendToClient(targetClient, meg);
            }
        }

        /// <summary>
        /// 广播消息到所有客户端
        /// </summary>
        /// <param name="meg">发送字符串</param>
        public void BroadcastMessage(string meg)
        {
            List<ClientSession> clients;
            lock (lockObject)
            {
                clients = new List<ClientSession>(sockets);
            }
            foreach (var client in clients)
            {
                SendToClient(client, meg);
            }
        }

        /// <summary>
        /// 安全发送消息到指定客户端
        /// </summary>
        /// <param name="client">目标客户端</param>
        /// <param name="message">消息内容</param>
        private void SendToClient(ClientSession client, string message)
        {
            if (client == null || client.Socket == null || !client.Socket.Connected)
            {
                return;
            }
            try
            {
                byte[] msgBytes = Encoding.UTF8.GetBytes(message);
                client.Socket.BeginSend(msgBytes, 0, msgBytes.Length, SocketFlags.None, 
                    (ar) =>
                    {
                        try
                        {
                            if (ar.AsyncState is Socket socket)
                            {
                                socket.EndSend(ar);
                            }
                        }
                        catch (SocketException ex)
                        {
                            DisconnectionEvent?.BeginInvoke(DateTime.Now, 
                                new Exception($"发送消息到 {client.EndPoint} 失败: {ex.Message}"), null, null);
                            RemoveClient(client);
                        }
                        catch (ObjectDisposedException)
                        {
                            RemoveClient(client);
                        }
                        catch (Exception ex)
                        {
                            DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
                            RemoveClient(client);
                        }
                    }, client.Socket);
            }
            catch (SocketException ex)
            {
                DisconnectionEvent?.BeginInvoke(DateTime.Now, 
                    new Exception($"发送消息到 {client.EndPoint} 失败: {ex.Message}"), null, null);
                RemoveClient(client);
            }
            catch (Exception ex)
            {
                DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
                RemoveClient(client);
            }
        }

        /// <summary>
        /// 服务器关闭
        /// </summary>
        public void CloseTCPServer()
        {
            try
            {
                _isconnet = false;
                List<ClientSession> clientsToClose;
                lock (lockObject)
                {
                    clientsToClose = new List<ClientSession>(sockets);
                    sockets.Clear();
                }
                
                foreach (var client in clientsToClose)
                {
                    try
                    {
                        if (client.Socket != null)
                        {
                            if (client.Socket.Connected)
                            {
                                client.Socket.Shutdown(SocketShutdown.Both);
                            }
                            client.Socket.Close();
                        }
                    }
                    catch { }
                }
                if (socketCore != null)
                {
                    try
                    {
                        socketCore.Close();
                    }
                    catch { }
                    finally
                    {
                        socketCore.Dispose();
                        socketCore = null;
                    }
                }
            }
            catch (Exception ex)
            {
                DisconnectionEvent?.BeginInvoke(DateTime.Now, ex, null, null);
            }
        }

        /// <summary>
        /// 获取当前连接的客户端数量
        /// </summary>
        /// <returns>客户端数量</returns>
        public int GetClientCount()
        {
            lock (lockObject)
            {
                return sockets.Count;
            }
        }

        /// <summary>
        /// 获取所有客户端信息
        /// </summary>
        /// <returns>客户端端点列表</returns>
        public List<IPEndPoint> GetAllClients()
        {
            lock (lockObject)
            {
                return sockets.Select(s => s.EndPoint).ToList();
            }
        }
    }

    internal class ClientSession
    {
        public Socket Socket { get; set; }

        public IPEndPoint EndPoint { get; set; }

        public byte[] Buffer { get; set; }

        public DateTime ConnectedTime { get; set; } = DateTime.Now;

        public override string ToString() => EndPoint?.ToString() ?? "Unknown";
    }
}
