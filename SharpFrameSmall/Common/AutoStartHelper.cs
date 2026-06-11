using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFrameSmall.Common
{
    public static class AutoStartHelper
    {
        /// <summary>
        /// 设置或取消开机自启动
        /// </summary>
        /// <param name="appName">应用名称</param>
        /// <param name="isAutoStart">true = 开机启动, false = 取消</param>
        public static void SetAutoStart(string appName, bool isAutoStart)
        {
            try
            {
                string exePath = Process.GetCurrentProcess().MainModule.FileName;
                string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
                {
                    if (key == null)
                        throw new Exception("无法打开注册表 Run 项");
                    if (isAutoStart)
                        key.SetValue(appName, "\"" + exePath + "\"");
                    else
                        key.DeleteValue(appName, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查是否已经设置开机自启动
        /// </summary>
        public static bool IsAutoStart(string appName)
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, false))
            {
                if (key == null) return false;
                string value = key.GetValue(appName) as string;
                return !string.IsNullOrEmpty(value);
            }
        }
    }
}
