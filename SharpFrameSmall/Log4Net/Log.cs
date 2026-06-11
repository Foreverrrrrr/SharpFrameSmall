using log4net;
using log4net.Config;
using Prism.Events;
using System;

[assembly: XmlConfigurator(ConfigFile = @"Log4Net\\log4net.config", Watch = true)]

namespace SharpFrameSmall.log4Net
{
    /// <summary>
    /// 运行日志
    /// </summary>
    public class Log
    {
        public enum State
        {
            Error,
            Normal,
            Run
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            ILog log = LogManager.GetLogger("Info");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(MainLogStructure message)
        {
            ILog log = LogManager.GetLogger("Info");
            if (log.IsInfoEnabled)
            {
                log.Info(message.Value);
            }
        }

        /// <summary>
        /// 错误日志带异常
        /// </summary>
        /// <param name="message">错误日志</param>
        public static void Error(string message, Exception ex)
        {
            ILog log = LogManager.GetLogger("Error");
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }

        /// <summary>
        /// 错误日志不带异常
        /// </summary>
        /// <param name="message">错误日志</param>
        public static void Error(string message)
        {
            ILog log = LogManager.GetLogger("Error");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
        }
    }

    /// <summary>
    /// 全局日志输出
    /// </summary>
    public class MainLogOutput : PubSubEvent<MainLogStructure> { }

    public class MainLogStructure
    {
        public string Time { get; set; }
        public string Level { get; set; } = "正常";
        public string Value { get; set; }
    }

    public class AutoLogOutput : PubSubEvent<string> { }

}
