using System;
using System.Threading;

namespace SharpFrameSmall.Logic.Base
{
    /// <summary>
    /// 流程方法标记特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ProductionThreadAttribute : Attribute { }

    /// <summary>
    /// 流程线程运行时信息
    /// </summary>
    public class ProductionThreadInfo
    {
        /// <summary>
        /// 实例对象
        /// </summary>
        public ProcessBase Class { get; set; }

        /// <summary>
        /// 线程对象
        /// </summary>
        public Thread New_Thread { get; set; }

        /// <summary>
        /// 暂停标志位
        /// </summary>
        public ManualResetEvent Interrupt { get; set; }

        /// <summary>
        /// 取消令牌源
        /// </summary>
        public CancellationTokenSource CancellationSource { get; set; }

        /// <summary>
        /// 线程名称
        /// </summary>
        public string Thread_Name { get; set; }

        /// <summary>
        /// 流程类名称
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 线程状态
        /// </summary>
        public bool Is_Running { get; set; }
    }
}
