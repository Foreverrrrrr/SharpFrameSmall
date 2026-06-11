using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharpFrameSmall.Structure.Parameter
{
    #region TypeCheckResult

    /// <summary>
    /// 表示类型检查和值解析的结果（统一的类型验证返回值）
    /// </summary>
    public struct TypeCheckResult
    {
        /// <summary>类型名称（如 "String", "Int32", "Double"）</summary>
        public string TypeName { get; }

        /// <summary>解析后的强类型值（失败时为原始字符串）</summary>
        public object ParsedValue { get; }

        /// <summary>是否解析成功</summary>
        public bool IsValid { get; }

        /// <summary>验证失败时的错误信息（成功时为 null）</summary>
        public string ErrorMessage { get; }

        public TypeCheckResult(string typeName, object parsedValue, bool isValid, string errorMessage = null)
        {
            TypeName = typeName;
            ParsedValue = parsedValue;
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        /// <summary>创建成功结果</summary>
        public static TypeCheckResult Success(string typeName, object parsedValue)
            => new TypeCheckResult(typeName, parsedValue, true);

        /// <summary>创建失败结果</summary>
        public static TypeCheckResult Fail(string typeName, object rawValue, string error)
            => new TypeCheckResult(typeName, rawValue, false, error);
    }

    #endregion

    /// <summary>
    /// 参数字段 - 参数的原子值单元
    /// <para>每个参数可以包含 N 个 ParameterField，实现灵活的多值参数</para>
    /// <para>例如："温度设置" 参数包含字段: 目标温度、上限、下限、报警温度、保温时间</para>
    /// </summary>
    public class ParameterField : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// 支持的类型映射（类型名称 → SelectedValue 索引）
        /// </summary>
        [JsonIgnore]
        public static readonly Dictionary<string, int> TypeMap = new Dictionary<string, int>
        {
            { "String",  0 },
            { "Boolean", 1 },
            { "Int32",   2 },
            { "Single",  3 },
            { "Double",  4 }
        };

        public ParameterField() { }

        /// <summary>
        /// 快速构造（自动推断类型）
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">字段值</param>
        /// <param name="unit">单位（可选，如 "°C", "mm", "MPa"）</param>
        /// <param name="description">字段描述（可选）</param>
        public ParameterField(string fieldName, object value, string unit = null, string description = null)
        {
            FieldName = fieldName;
            Unit = unit;
            Description = description;
            InitializeValue(value);
        }

        private string _fieldName;
        /// <summary>
        /// 字段名称（如 "TargetTemp", "UpperLimit"）
        /// </summary>
        public string FieldName
        {
            get => _fieldName;
            set => SetProperty(ref _fieldName, value);
        }

        private object _value;
        /// <summary>
        /// 字段值
        /// </summary>
        public object Value
        {
            get => _value;
            set
            {
                if (SetProperty(ref _value, value))
                {
                    OnPropertyChanged(nameof(ValidationError));
                    OnPropertyChanged(nameof(HasError));
                }
            }
        }

        private Type _valueType;
        /// <summary>
        /// 字段值类型
        /// </summary>
        public Type ValueType
        {
            get => _valueType;
            set
            {
                if (SetProperty(ref _valueType, value) && value != null)
                {
                    SyncSelectedValueFromType(value);
                }
            }
        }

        private int _selectedValue;
        /// <summary>
        /// 类型选择索引（对应 ComboBox 绑定）
        /// </summary>
        public int SelectedValue
        {
            get => _selectedValue;
            set
            {
                if (SetProperty(ref _selectedValue, value))
                {
                    OnPropertyChanged(nameof(ValidationError));
                    OnPropertyChanged(nameof(HasError));
                }
            }
        }

        private string _unit;
        /// <summary>
        /// 单位（如 "°C", "mm", "s", "MPa"）
        /// </summary>
        public string Unit
        {
            get => _unit;
            set => SetProperty(ref _unit, value);
        }

        private string _description;
        /// <summary>
        /// 字段描述/备注
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        /// <summary>
        /// 类型变更命令（UI绑定）
        /// </summary>
        [JsonIgnore]
        public DelegateCommand<object> ComboBoxChanged { get; set; }

        /// <summary>
        /// 初始化值（自动推断 ValueType 和 SelectedValue）
        /// </summary>
        public void InitializeValue(object value)
        {
            Value = value;
            if (value != null)
            {
                ValueType = value.GetType();
            }
        }

        /// <summary>
        /// 获取强类型值
        /// </summary>
        public T GetValue<T>()
        {
            if (Value == null) return default;
            return (T)Convert.ChangeType(Value, typeof(T));
        }

        /// <summary>
        /// 深拷贝字段
        /// </summary>
        public ParameterField Clone()
        {
            return new ParameterField
            {
                FieldName = this.FieldName,
                Value = this.Value,
                ValueType = this.ValueType,
                SelectedValue = this.SelectedValue,
                Unit = this.Unit,
                Description = this.Description
            };
        }

        /// <summary>
        /// 根据 Type 同步 SelectedValue
        /// </summary>
        private void SyncSelectedValueFromType(Type type)
        {
            if (type != null && TypeMap.TryGetValue(type.Name, out int index))
            {
                SelectedValue = index;
            }
        }

        #region 输入验证

        /// <summary>
        /// 统一类型检查：验证并解析当前 Value 是否符合 SelectedValue 指定的类型
        /// <para>返回 TypeCheckResult 包含：类型名、解析值、是否有效、错误信息</para>
        /// </summary>
        public TypeCheckResult TypeCheck()
        {
            string input = Convert.ToString(Value);

            switch (SelectedValue)
            {
                case 0: // String
                    // String 类型不做内容限制，空值/业务校验由上层负责
                    return TypeCheckResult.Success("String", input ?? string.Empty);

                case 1: // Boolean
                    if (bool.TryParse(input, out var boolVal))
                        return TypeCheckResult.Success("Boolean", boolVal);
                    return TypeCheckResult.Fail("Boolean", input ?? string.Empty,
                        $"值 \"{input}\" 不是有效的布尔值，请输入 True 或 False");

                case 2: // Int32
                    if (int.TryParse(input, out var intVal))
                        return TypeCheckResult.Success("Int32", intVal);
                    return TypeCheckResult.Fail("Int32", input ?? string.Empty,
                        $"值 \"{input}\" 不是有效的整数，请输入整数（如 0, 100, -5）");

                case 3: // Single (Float)
                    if (float.TryParse(input, out var floatVal))
                        return TypeCheckResult.Success("Single", floatVal);
                    return TypeCheckResult.Fail("Single", input ?? string.Empty,
                        $"值 \"{input}\" 不是有效的浮点数（Single），请输入数字（如 3.14）");

                case 4: // Double
                    if (double.TryParse(input, out var doubleVal))
                        return TypeCheckResult.Success("Double", doubleVal);
                    return TypeCheckResult.Fail("Double", input ?? string.Empty,
                        $"值 \"{input}\" 不是有效的双精度浮点数（Double），请输入数字（如 3.14159）");

                default:
                    return TypeCheckResult.Fail("未知", input ?? string.Empty,
                        $"未知的类型索引: {SelectedValue}");
            }
        }

        /// <summary>
        /// 验证当前 Value 是否符合 SelectedValue 指定的类型
        /// </summary>
        /// <returns>错误信息，验证通过返回 null</returns>
        public string ValidateValue()
        {
            string input = Convert.ToString(Value);

            // 空值对所有类型都有效（由业务层决定是否允许空值）
            if (string.IsNullOrEmpty(input))
                return null;

            var result = TypeCheck();
            return result.IsValid ? null : result.ErrorMessage;
        }

        /// <summary>
        /// 当前验证错误信息（null 表示无错误）
        /// </summary>
        [JsonIgnore]
        public string ValidationError => ValidateValue();

        /// <summary>
        /// 是否存在验证错误
        /// </summary>
        [JsonIgnore]
        public bool HasError => ValidationError != null;

        /// <summary>
        /// 类型的友好显示名称
        /// </summary>
        [JsonIgnore]
        public string TypeDisplayName
        {
            get
            {
                var pair = TypeMap.FirstOrDefault(kv => kv.Value == SelectedValue);
                return pair.Key ?? "未知";
            }
        }

        #endregion

        #region IDataErrorInfo（WPF 绑定自动验证）

        /// <summary>
        /// IDataErrorInfo.Error - 全局错误（不使用）
        /// </summary>
        [JsonIgnore]
        string IDataErrorInfo.Error => ValidationError;

        /// <summary>
        /// IDataErrorInfo 索引器 - WPF 会自动在绑定时查询
        /// </summary>
        [JsonIgnore]
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == nameof(Value))
                    return ValidateValue();
                return null;
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public override string ToString()
        {
            return $"{FieldName} = {Value}" + (string.IsNullOrEmpty(Unit) ? "" : $" {Unit}");
        }
    }
}
