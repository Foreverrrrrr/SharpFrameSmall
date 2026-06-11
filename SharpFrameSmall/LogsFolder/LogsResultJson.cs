using System;
using System.Linq;

namespace SharpFrameSmall.LogsFolder
{
    public class LogsResultJson
    {
        /// <summary>
        /// 机台编号
        /// </summary>
        public string machine_id { get; set; }
        /// <summary>
        /// 结果 0 pass 1 fail
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// NG原因
        /// </summary>
        public string fail_reason { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string utime { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
    }
}
