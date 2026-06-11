using SharpFrameSmall.Common;
using System;
using System.Linq;

namespace SharpFrameSmall.LogsFolder
{
    public class ErrorCode
    {
        public ErrorCode()
        {

        }

        public ErrorCode(ErrorCode error)
        {
            error_class = error.error_class;
            error_code = error.error_code;
            error_description = error.error_description;
            error_analysis = error.error_analysis;
            plc_site = error.plc_site;
        }

        /// <summary>
        /// 错误类别
        /// </summary>
        [ExcelColumn(0, HeaderName = "error_class", IsGroupKey = true)]
        public string error_class { get; set; }
        /// <summary>
        /// 异常代码
        /// </summary>
        [ExcelColumn(1, HeaderName = "error_code")]
        public string error_code { get; set; }
        /// <summary>
        /// 错误详情
        /// </summary>
        [ExcelColumn(2, HeaderName = "error_description")]
        public string error_description { get; set; }
        /// <summary>
        /// 维护建议
        /// </summary>
        [ExcelColumn(3, HeaderName = "error_analysis")]
        public string error_analysis { get; set; }
        /// <summary>
        /// PLC地址
        /// </summary>
        [ExcelColumn(4, HeaderName = "plc_site")]
        public string plc_site { get; set; }
    }
}
