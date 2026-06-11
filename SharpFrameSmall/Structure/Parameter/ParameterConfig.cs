using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 参数配置文件访问 - 读写 Parameter.config（AppSettings）
    /// <para>职责单一：只负责 .config 文件的 key-value 读写</para>
    /// </summary>
    public static class ParameterConfig
    {
        private static readonly object _configLock = new object();

        /// <summary>
        /// 获取 Parameter.config 文件路径
        /// </summary>
        private static string GetConfigFilePath()
        {
            string baseDir = Directory.GetParent(
                AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\')).FullName;
            return Path.Combine(baseDir, "Structure", "Parameter", "Parameter.config");
        }

        /// <summary>
        /// 打开配置（内部共享方法）
        /// </summary>
        private static Configuration OpenConfig()
        {
            string configFile = GetConfigFilePath();

            string configDir = Path.GetDirectoryName(configFile);
            if (!Directory.Exists(configDir))
                throw new DirectoryNotFoundException($"配置目录不存在: {configDir}");
            if (!File.Exists(configFile))
                throw new FileNotFoundException($"配置文件不存在: {configFile}");

            var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// 读取配置项的值
        /// </summary>
        /// <param name="name">配置项名称</param>
        /// <returns>配置值</returns>
        /// <exception cref="KeyNotFoundException">配置项不存在</exception>
        public static string GetValue(string name)
        {
            lock (_configLock)
            {
                var config = OpenConfig();
                if (config.AppSettings.Settings[name] == null)
                    throw new KeyNotFoundException($"配置项 '{name}' 未找到。");
                return config.AppSettings.Settings[name].Value;
            }
        }

        /// <summary>
        /// 写入配置项的值
        /// </summary>
        /// <param name="name">配置项名称</param>
        /// <param name="value">配置值</param>
        /// <exception cref="KeyNotFoundException">配置项不存在</exception>
        public static void SetValue(string name, string value)
        {
            lock (_configLock)
            {
                var config = OpenConfig();
                if (config.AppSettings.Settings[name] == null)
                    throw new KeyNotFoundException($"配置项 '{name}' 未找到，无法写入。");
                config.AppSettings.Settings[name].Value = value;
                config.Save();
            }
        }

        /// <summary>
        /// 尝试读取配置项（不抛异常）
        /// </summary>
        /// <param name="name">配置项名称</param>
        /// <param name="value">输出值</param>
        /// <returns>是否成功</returns>
        public static bool TryGetValue(string name, out string value)
        {
            try
            {
                value = GetValue(name);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
}
