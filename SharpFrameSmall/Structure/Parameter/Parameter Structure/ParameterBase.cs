using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharpFrameSmall.Structure.Parameter
{
    #region ValidationResult

    /// <summary>
    /// 统一验证结果 - 参数级和字段级错误的聚合
    /// </summary>
    public class ValidationResult
    {
        /// <summary>参数级错误列表</summary>
        public List<string> ParameterErrors { get; } = new List<string>();

        /// <summary>字段级错误列表（字段名 → 错误信息）</summary>
        public List<KeyValuePair<string, string>> FieldErrors { get; } = new List<KeyValuePair<string, string>>();

        /// <summary>是否全部验证通过</summary>
        public bool IsValid => ParameterErrors.Count == 0 && FieldErrors.Count == 0;

        /// <summary>所有错误合并为一个列表</summary>
        public List<string> AllErrors
        {
            get
            {
                var all = new List<string>(ParameterErrors);
                foreach (var kv in FieldErrors)
                    all.Add($"字段 \"{kv.Key}\": {kv.Value}");
                return all;
            }
        }

        /// <summary>格式化为用户友好的多行消息</summary>
        public string FormatMessage()
        {
            if (IsValid) return string.Empty;
            var errors = AllErrors;
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"发现 {errors.Count} 个错误：");
            for (int i = 0; i < errors.Count; i++)
                sb.AppendLine($"  {i + 1}. {errors[i]}");
            return sb.ToString();
        }
    }

    #endregion
    /// <summary>
    /// 参数全功能基类 - 所有参数类型的根基类
    /// <para>核心能力: Fields字段集合、INPC、验证、深拷贝</para>
    /// <para>新的参数类型应继承此类，通过 Fields 定义自己的字段结构</para>
    /// </summary>
    public abstract class ParameterBase : IParameter
    {
        private int _id;
        private string _name;
        private string _description;

        public ParameterBase()
        {
            Fields = new ObservableCollection<ParameterField>();
        }

        /// <summary>
        /// 参数唯一标识
        /// </summary>
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// 参数描述/备注
        /// </summary>
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        /// <summary>
        /// 参数类别标识（子类必须实现）
        /// </summary>
        [JsonIgnore]
        public abstract string Category { get; }

        #region Fields 字段集合

        /// <summary>
        /// 参数字段集合（核心：一个参数可以包含N个字段值）
        /// <para>通过 AddField / GetField / this[fieldName] 操作</para>
        /// </summary>
        public ObservableCollection<ParameterField> Fields { get; set; }

        /// <summary>
        /// 字段数量
        /// </summary>
        [JsonIgnore]
        public int FieldCount => Fields?.Count ?? 0;

        /// <summary>
        /// 按名称索引字段（快速访问）
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns>匹配的字段，不存在则返回 null</returns>
        [JsonIgnore]
        public ParameterField this[string fieldName]
        {
            get => Fields?.FirstOrDefault(f => f.FieldName == fieldName);
        }

        /// <summary>
        /// 添加一个字段
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">字段值（自动推断类型）</param>
        /// <param name="unit">单位（可选）</param>
        /// <param name="description">描述（可选）</param>
        /// <returns>添加的字段实例（方便链式调用）</returns>
        public ParameterField AddField(string fieldName, object value, string unit = null, string description = null)
        {
            var field = new ParameterField(fieldName, value, unit, description);
            Fields.Add(field);
            return field;
        }

        /// <summary>
        /// 获取指定字段
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns>字段实例</returns>
        /// <exception cref="ArgumentException">字段不存在时抛出</exception>
        public ParameterField GetField(string fieldName)
        {
            var field = this[fieldName];
            if (field == null)
                throw new ArgumentException($"参数 '{Name}' 中不存在字段 '{fieldName}'");
            return field;
        }

        /// <summary>
        /// 获取字段的强类型值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="fieldName">字段名称</param>
        /// <returns>转换后的值</returns>
        public T GetFieldValue<T>(string fieldName)
        {
            return GetField(fieldName).GetValue<T>();
        }

        /// <summary>
        /// 设置字段值
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">新值</param>
        public void SetFieldValue(string fieldName, object value)
        {
            GetField(fieldName).Value = value;
        }

        /// <summary>
        /// 尝试获取字段值（不抛异常）
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">输出值</param>
        /// <returns>是否成功获取</returns>
        public bool TryGetFieldValue<T>(string fieldName, out T value)
        {
            var field = this[fieldName];
            if (field?.Value != null)
            {
                try
                {
                    value = field.GetValue<T>();
                    return true;
                }
                catch { }
            }
            value = default;
            return false;
        }

        /// <summary>
        /// 判断是否存在指定字段
        /// </summary>
        public bool HasField(string fieldName)
        {
            return this[fieldName] != null;
        }

        #endregion

        #region 验证

        /// <summary>
        /// 统一验证入口 - 一次调用返回参数级 + 字段级所有错误
        /// <para>子类重写 Validate() 即可自动纳入此方法</para>
        /// </summary>
        /// <returns>ValidationResult 包含所有错误</returns>
        public ValidationResult ValidateAll()
        {
            var result = new ValidationResult();

            // 1. 参数级验证（Name 非空 + 子类自定义规则）
            if (!Validate(out string paramError))
                result.ParameterErrors.Add(paramError);

            // 2. 字段级验证（所有 Fields 的类型检查）
            if (Fields != null)
            {
                foreach (var field in Fields)
                {
                    var error = field.ValidateValue();
                    if (error != null)
                        result.FieldErrors.Add(new KeyValuePair<string, string>(field.FieldName, error));
                }
            }

            return result;
        }

        /// <summary>
        /// 验证所有字段的值是否符合类型要求
        /// </summary>
        /// <param name="errors">每个字段的错误信息列表（字段名→错误信息）</param>
        /// <returns>所有字段是否都验证通过</returns>
        public bool ValidateAllFields(out List<KeyValuePair<string, string>> errors)
        {
            errors = new List<KeyValuePair<string, string>>();
            if (Fields == null) return true;

            foreach (var field in Fields)
            {
                var error = field.ValidateValue();
                if (error != null)
                {
                    errors.Add(new KeyValuePair<string, string>(field.FieldName, error));
                }
            }
            return errors.Count == 0;
        }

        /// <summary>
        /// 检查所有字段是否都有效（快速判断，无错误详情）
        /// </summary>
        [JsonIgnore]
        public bool IsAllFieldsValid
        {
            get
            {
                if (Fields == null) return true;
                return Fields.All(f => !f.HasError);
            }
        }

        #endregion

        /// <summary>
        /// 深拷贝（子类必须实现）
        /// </summary>
        public abstract IParameter DeepClone();

        /// <summary>
        /// 参数验证（子类可重写，默认验证Name非空）
        /// </summary>
        public virtual bool Validate(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                errorMessage = $"参数(ID={ID})的名称不能为空";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

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

        /// <summary>
        /// 通过JSON序列化实现通用深拷贝
        /// </summary>
        protected T CloneViaJson<T>() where T : class
        {
            var json = JsonConvert.SerializeObject(this, ParameterJsonTool.DefaultSettings);
            return JsonConvert.DeserializeObject<T>(json, ParameterJsonTool.DefaultSettings);
        }

        /// <summary>
        /// 从另一个 ParameterBase 复制基础属性和字段
        /// </summary>
        protected void CopyBaseFrom(ParameterBase source)
        {
            if (source == null) return;
            ID = source.ID;
            Name = source.Name;
            Description = source.Description;
            if (source.Fields != null)
            {
                Fields.Clear();
                foreach (var field in source.Fields)
                {
                    Fields.Add(field.Clone());
                }
            }
        }

        public override string ToString()
        {
            return $"[{Category}] {Name} (ID={ID}, Fields={FieldCount})";
        }
    }
}
