using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFrameSmall.ViewModels.Structure
{
    public enum UserLevel
    {
        /// <summary>
        /// 操作员
        /// </summary>
        Operator = 0,
        /// <summary>
        /// 技术员
        /// </summary>
        Technician = 1,
        /// <summary>
        /// 工程师
        /// </summary>
        Engineer = 2,
        /// <summary>
        /// 系统管理员
        /// </summary>
        Admin = 3
    }

    public class User
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public UserLevel Level { get; set; }
    }


}
