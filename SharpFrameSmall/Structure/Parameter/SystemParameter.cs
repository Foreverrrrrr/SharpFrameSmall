using Newtonsoft.Json;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 系统参数 - 用于全局系统配置项
    /// <para>继承自 ValueParameter，自动拥有 Value/ValueType/SelectedValue/ComboBoxChanged 功能</para>
    /// </summary>
    public class SystemParameter : ValueParameter
    {
        public SystemParameter() { }

        /// <summary>
        /// 拷贝构造
        /// </summary>
        public SystemParameter(SystemParameter source)
        {
            CopyFrom(source);
        }

        /// <summary>
        /// 快速构造
        /// </summary>
        public SystemParameter(int id, string name, object value)
        {
            ID = id;
            Name = name;
            InitializeValue(value);
        }

        /// <summary>
        /// 参数类别
        /// </summary>
        [JsonIgnore]
        public override string Category => "System";

        /// <summary>
        /// 深拷贝
        /// </summary>
        public override IParameter DeepClone()
        {
            return CloneViaJson<SystemParameter>();
        }
    }
}
