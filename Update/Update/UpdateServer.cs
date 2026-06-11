using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Update.Common.Update
{
    public class UpdateServer
    {
        private HttpListener listener;

        private string ServerFolder = AppDomain.CurrentDomain.BaseDirectory;

        public Action<DateTime, string> UpdateLog;

        public UpdateServer(string folder,int port=12222)
        {
            listener = new HttpListener();
            listener.Prefixes.Add($"http://+:{port}/");
            listener.Start();
            listener.BeginGetContext(OnRequest, null);
            Console.WriteLine($"HTTP 更新服务器启动，监听端口 {port}");
            this.ServerFolder = folder;
        }

        public void Stop()
        {
            listener.Stop();
        }

        private void OnRequest(IAsyncResult ar)
        {
            if (!listener.IsListening) return;
            var context = listener.EndGetContext(ar);
            listener.BeginGetContext(OnRequest, null);
            string url = context.Request.RawUrl.ToLower();
            try
            {
                if (url.Contains("/version"))
                {
                    string versionFile = Path.Combine(ServerFolder, "version.txt");
                    if (!File.Exists(versionFile))
                    {
                        context.Response.StatusCode = 404;
                        context.Response.Close();
                        return;
                    }
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(versionFile));
                    context.Response.OutputStream.Write(data, 0, data.Length);
                    context.Response.Close();
                }
                else if (url.StartsWith("/file/"))
                {
                    string filename = url.Substring("/file/".Length);
                    string filePath = Path.Combine(ServerFolder, filename);
                    if (!File.Exists(filePath))
                    {
                        context.Response.StatusCode = 404;
                        context.Response.Close();
                        return;
                    }
                    context.Response.ContentType = "application/octet-stream";
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        context.Response.ContentLength64 = fs.Length;
                        byte[] buffer = new byte[5 * 1024 * 1024];
                        int bytesRead;
                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            context.Response.OutputStream.Write(buffer, 0, bytesRead);
                            context.Response.OutputStream.Flush();
                        }
                    }
                    context.Response.OutputStream.Close();
                    context.Response.Close();
                }
                else
                {
                    context.Response.StatusCode = 404;
                    context.Response.Close();
                }
            }
            catch
            {
                context.Response.StatusCode = 500;
                context.Response.Close();
            }
        }
    }
}
