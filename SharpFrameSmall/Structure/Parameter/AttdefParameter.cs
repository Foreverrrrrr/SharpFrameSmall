using Newtonsoft.Json;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 贴附参数
    /// </summary>
    public class AttdefParameter : ParameterBase
    {
        public AttdefParameter() { }

        /// <summary>
        /// 拷贝构造
        /// </summary>
        public AttdefParameter(AttdefParameter source)
        {
            CopyBaseFrom(source);
        }

        /// <summary>
        /// 快速构造（字段通过 AddField 添加）
        /// </summary>
        public AttdefParameter(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// 快速构造（直接传入字段数组）
        /// </summary>
        public AttdefParameter(int id, string name, params ParameterField[] fields)
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
        public override string Category => "Attdef";

        /// <summary>
        /// 深拷贝
        /// </summary>
        public override IParameter DeepClone()
        {
            return CloneViaJson<AttdefParameter>();
        }
    }
}
