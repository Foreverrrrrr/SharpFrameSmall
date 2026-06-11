using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFrameSmall.Update
{
    public class CheckUpdate
    {
        private readonly string localVersionPath = 
            Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName, "version.json"); // 本地版本文件
        private readonly string localDebugFolder = 
            Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName); // bin文件夹
        //private readonly string localVersionPath = @"D:\环境搭建\新建文件夹\bin\version.json";
        //private readonly string localDebugFolder = @"D:\\环境搭建\\新建文件夹\\bin";

        public CheckUpdate(string path)
        {
            string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Update", "Update.exe");
            string mainExePath = Process.GetCurrentProcess().MainModule.FileName;
            string arguments = $"\"{mainExePath}\" \"{path}\" \"{localVersionPath}\" \"{localDebugFolder}\"";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = updaterPath,
                Arguments = arguments,
                CreateNoWindow = false,
                UseShellExecute = false,
            };
            Process.Start(psi);
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
