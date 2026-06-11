using Newtonsoft.Json;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 标签参数 - 支持多字段的参数类型
    /// <para>继承自 ParameterBase，通过 Fields 实现灵活的多字段结构</para>
    /// <para>示例：new LabelParameter(1, "标签1") 然后 .AddField("Content", "Hello") .AddField("FontSize", 12, "pt")</para>
    /// </summary>
    public class LabelParameter : ParameterBase
    {
        public LabelParameter() { }

        /// <summary>
        /// 拷贝构造
        /// </summary>
        public LabelParameter(LabelParameter source)
        {
            CopyBaseFrom(source);
        }

        /// <summary>
        /// 快速构造（字段通过 AddField 添加）
        /// </summary>
        public LabelParameter(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// 快速构造（直接传入字段数组）
        /// </summary>
        public LabelParameter(int id, string name, params ParameterField[] fields)
        {
            ID = id;
            Name = name;
            if (fields != null)
            {
                foreach (var f in fields)
                    Fields.Add(f);
            }
        }

        /// <summary>
        /// 参数类别
        /// </summary>
        [JsonIgnore]
        public override string Category => "Label";

        /// <summary>
        /// 深拷贝
        /// </summary>
        public override IParameter DeepClone()
        {
            return CloneViaJson<LabelParameter>();
        }
    }
}
