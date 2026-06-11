using Newtonsoft.Json;
using System;
using System.Linq;

namespace SharpFrameSmall.Structure.Parameter
{
    public abstract class ValueParameter : ParameterBase
    {
        private const string DefaultFieldName = "Value";

        /// <summary>
        /// 查找默认字段
        /// </summary>
        private ParameterField FindDefaultField()
        {
            return this[DefaultFieldName];
        }

        /// <summary>
        /// 获取或创建默认字段
        /// </summary>
        private ParameterField EnsureDefaultField()
        {
            var field = this[DefaultFieldName];
            if (field == null)
            {
                field = new ParameterField { FieldName = DefaultFieldName };
                Fields.Add(field);
            }
            return field;
        }

        /// <summary>
        /// 是否正在使用默认字段模式
        /// <para>true = 存在名为 "Value" 的默认字段</para>
        /// <para>false = 使用自定义字段名称</para>
        /// </summary>
        [JsonIgnore]
        public bool HasDefaultField => FindDefaultField() != null;

        /// <summary>
        /// 参数值
        /// <para>getter 不会自动创建字段；若无 "Value" 字段则返回 null</para>
        /// </summary>
        [JsonIgnore]
        public virtual object Value
        {
            get => FindDefaultField()?.Value;
            set
            {
                EnsureDefaultField().Value = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 参数值类型
        /// </summary>
        [JsonIgnore]
        public virtual Type ValueType
        {
            get => FindDefaultField()?.ValueType;
            set
            {
                EnsureDefaultField().ValueType = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 类型选择索引
        /// </summary>
        [JsonIgnore]
        public virtual int SelectedValue
        {
            get => FindDefaultField()?.SelectedValue ?? 0;
            set
            {
                EnsureDefaultField().SelectedValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 初始化值 自动推断 ValueType 和 SelectedValue
        /// </summary>
        protected void InitializeValue(object value)
        {
            EnsureDefaultField().InitializeValue(value);
        }

        /// <summary>
        /// 从另一个 ValueParameter 复制所有属性
        /// </summary>
        protected void CopyFrom(ValueParameter source)
        {
            if (source == null) return;
            CopyBaseFrom(source);
        }

        /// <summary>
        /// 获取强类型值
        /// </summary>
        public T GetValue<T>()
        {
            var field = FindDefaultField();
            if (field == null)
                throw new InvalidOperationException(
                    $"参数 '{Name}' 不存在默认字段 \"{DefaultFieldName}\"，请使用 GetFieldValue<T>(fieldName) 访问自定义字段");
            return field.GetValue<T>();
        }

        /// <summary>
        /// 参数验证
        /// <para>多字段模式（无 "Value" 默认字段）：只执行基类验证（Name非空 + 字段级类型检查）</para>
        /// <para>单值模式（有 "Value" 默认字段）：额外检查值不为空</para>
        /// </summary>
        public override bool Validate(out string errorMessage)
        {
            if (!base.Validate(out errorMessage))
                return false;
            var defaultField = FindDefaultField();
            if (defaultField != null && defaultField.Value == null)
            {
                errorMessage = $"参数 '{Name}' 的值不能为空";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
