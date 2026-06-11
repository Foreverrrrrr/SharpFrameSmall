using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Update.Common.Update
{
    public class Updater
    {
        private readonly string serverUrl;
        private readonly string localFolder;
        private readonly string versionFile;

        public Action<long, long> DownloadProgress; // 下载进度回调
        public Action<string> LogMessage;           // 日志消息回调

        public Updater(string serverUrl, string localFolder= "version.txt")
        {
            this.serverUrl = serverUrl.TrimEnd('/');
            this.localFolder = localFolder;
            this.versionFile = "version.txt";
            if (!Directory.Exists(localFolder))
                Directory.CreateDirectory(localFolder);
        }

        public async Task<string> GetServerVersionAsync()
        {
            using (var client = new WebClient())
            {
                string url = $"{serverUrl}/version";
                return await client.DownloadStringTaskAsync(url);
            }
        }

        public string GetLocalVersion()
        {
            if (!File.Exists(versionFile)) return "0.0.0";
            return File.ReadAllText(versionFile).Trim();
        }

        public async Task DownloadFileAsync(string fileName)
        {
            string url = $"{serverUrl}/file/{fileName}";
            string localPath = Path.Combine(localFolder, fileName);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream responseStream = response.GetResponseStream())
            using (FileStream fs = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                long totalBytes = response.ContentLength;
                long receivedBytes = 0;
                byte[] buffer = new byte[5 * 1024 * 1024];
                int bytesRead;
                while ((bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fs.WriteAsync(buffer, 0, bytesRead);
                    receivedBytes += bytesRead;
                    DownloadProgress?.Invoke(receivedBytes, totalBytes);
                }
            }
        }

        public async Task<bool> CheckAndUpdateAsync(string updateFileName)
        {
            string localVersion = GetLocalVersion();
            string serverVersion = (await GetServerVersionAsync()).Trim();
            LogMessage?.Invoke($"本地版本: {localVersion}, 服务器版本: {serverVersion}");
            if (localVersion != serverVersion)
            {
                LogMessage?.Invoke("发现新版本，开始下载...");
                await DownloadFileAsync(updateFileName);
                File.WriteAllText(versionFile, serverVersion, Encoding.UTF8);
                LogMessage?.Invoke("更新完成");
                return true;
            }
            else
            {
                LogMessage?.Invoke("已是最新版本");
                return false;
            }
        }
    }
}
