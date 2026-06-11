using System;
using System.Linq;

namespace SharpFrameSmall.LogsFolder
{
    public class LogsRecipeJson
    {
        /// <summary>
        /// 机台编号
        /// </summary>
        public string machine_id { get; set; }
        /// <summary>
        /// 扭力设定值
        /// </summary>
        public float torquesetting { get; set; }
        /// <summary>
        /// 压力设定值
        /// </summary>
        public float floatpressuresetting { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public int utime { get; set; }
    }
}
