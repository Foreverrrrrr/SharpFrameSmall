using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpFrameSmall.LogsFolder
{
    public class LogsEventJson
    {
        /// <summary>
        /// 数据类型，STATUS/PCS
        /// </summary>
        public string data_type { get; set; } = "STATUS";

        /// <summary>
        /// 数据上抛时间，13位时间戳
        /// </summary>
        public string timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

        /// <summary>
        /// 数据JSON对象
        /// </summary>
        public DataContent data { get; set; } = new DataContent();

        public class DataContent
        {
            /// <summary>
            /// 厂区
            /// </summary>
            public string SITE_ID { get; set; }
            /// <summary>
            /// 厂别
            /// </summary>
            public string PLANT_ID { get; set; }
            /// <summary>
            /// 车间
            /// </summary>
            public string WORKSHOP { get; set; }
            /// <summary>
            /// 线别
            /// </summary>
            public string LINE_ID { get; set; }
            /// <summary>
            /// 工站
            /// </summary>
            public string STATION_ID { get; set; }
            /// <summary>
            /// 设备名称
            /// </summary>
            public string MACHINE_NAME { get; set; }
            /// <summary>
            /// 设备编号
            /// </summary>
            public string MACHINE_ID { get; set; }
            /// <summary>
            /// 设备财编
            /// </summary>
            public string EQUIPMENT_ID { get; set; }
            /// <summary>
            /// IP地址
            /// </summary>
            public string IP_ADDRESS { get; set; }
            /// <summary>
            /// 品牌
            /// </summary>
            public string BRAND { get; set; }
            /// <summary>
            /// 设备型号
            /// </summary>
            public string MODEL { get; set; }
            /// <summary>
            /// 机种
            /// </summary>
            public string MODEL_ID { get; set; }
            /// <summary>
            /// 程序名称
            /// </summary>
            public string PROGRAM_ID { get; set; }
            /// <summary>
            /// 机台类型
            /// </summary>
            public string MACHINE_TYPE { get; set; }
            /// <summary>
            /// 数据上抛频率
            /// </summary>
            public string UPLOAD_FREQUENCY { get; set; }
            /// <summary>
            /// 设备状态：1/2/3 代表 Run/Wait/Error
            /// </summary>
            public string MACHINE_STATUS { get; set; }
            /// <summary> 
            /// 状态变化触发：0/1 0周期触发 1状态触发
            /// </summary>
            public string TRIGGER { get; set; }
            /// <summary>
            /// 报警代码数组，空则表示无报警
            /// </summary>
            public List<string> MACHINE_ERROR { get; set; } = new List<string>();

            public List<string> ERROR_CODE { get; set; } = new List<string>();

            public List<string> ERROR_DESCRIPTION { get; set; } = new List<string>();

            public List<string> ERROR_ANALYSIS { get; set; } = new List<string>();
            /// <summary>
            /// 数据生成时间戳
            /// </summary>
            public string UTIME { get; set; }
        }
    }
}
