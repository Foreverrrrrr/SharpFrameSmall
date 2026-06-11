using System.ComponentModel;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 参数接口 - 所有参数类型的统一契约
    /// <para>任何参数类型都必须实现此接口，确保参数管理系统的一致性</para>
    /// </summary>
    public interface IParameter : INotifyPropertyChanged
    {
        /// <summary>
        /// 参数唯一标识
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 参数描述/备注
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 参数类别标识（如 "System", "Technology", "Modbus" 等）
        /// <para>子类通过重写此属性来标识自己的类别</para>
        /// </summary>
        string Category { get; }

        /// <summary>
        /// 深拷贝当前参数实例
        /// </summary>
        /// <returns>当前参数的完整副本</returns>
        IParameter DeepClone();

        /// <summary>
        /// 验证参数的合法性
        /// </summary>
        /// <param name="errorMessage">验证失败时的错误信息</param>
        /// <returns>验证是否通过</returns>
        bool Validate(out string errorMessage);
    }
}
