using Newtonsoft.Json;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// Modbus通讯参数
    /// <para>继承自 ParameterBase，拥有独立的通讯属性结构</para>
    /// </summary>
    public class ModbusParameter : ParameterBase
    {
        public ModbusParameter() { }

        /// <summary>
        /// 拷贝构造
        /// </summary>
        public ModbusParameter(ModbusParameter source)
        {
            if (source == null) return;
            CopyBaseFrom(source);
            DataType = source.DataType;
            DataTypeString = source.DataTypeString;
            StartAddress = source.StartAddress;
            Length = source.Length;
            TriggerModel = source.TriggerModel;
        }

        /// <summary>
        /// 快速构造
        /// </summary>
        public ModbusParameter(int id, string name, ModbusDataType type, string startAddress, uint length, string triggerModel)
        {
            ID = id;
            Name = name;
            DataTypeString = type.ToString();
            DataType = type;
            StartAddress = startAddress;
            Length = length;
            TriggerModel = triggerModel;
        }

        private string _dataTypeString;
        /// <summary>
        /// 数据类型名称（字符串形式，用于显示）
        /// </summary>
        public string DataTypeString
        {
            get => _dataTypeString;
            set => SetProperty(ref _dataTypeString, value);
        }

        private ModbusDataType _dataType;
        /// <summary>
        /// Modbus数据类型
        /// </summary>
        public ModbusDataType DataType
        {
            get => _dataType;
            set
            {
                if (SetProperty(ref _dataType, value))
                    DataTypeString = value.ToString();
            }
        }

        private string _startAddress;
        /// <summary>
        /// 起始地址
        /// </summary>
        public string StartAddress
        {
            get => _startAddress;
            set => SetProperty(ref _startAddress, value);
        }

        private uint _length;
        /// <summary>
        /// 数据长度
        /// </summary>
        [JsonProperty("length")]
        public uint Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }

        private string _triggerModel;
        /// <summary>
        /// 触发模式
        /// </summary>
        public string TriggerModel
        {
            get => _triggerModel;
            set => SetProperty(ref _triggerModel, value);
        }

        /// <summary>
        /// 参数类别
        /// </summary>
        [JsonIgnore]
        public override string Category => "Modbus";

        /// <summary>
        /// 深拷贝
        /// </summary>
        public override IParameter DeepClone()
        {
            return CloneViaJson<ModbusParameter>();
        }

        /// <summary>
        /// 参数验证（含地址校验）
        /// </summary>
        public override bool Validate(out string errorMessage)
        {
            if (!base.Validate(out errorMessage))
                return false;

            if (string.IsNullOrWhiteSpace(StartAddress))
            {
                errorMessage = $"Modbus参数 '{Name}' 的起始地址不能为空";
                return false;
            }

            if (Length == 0)
            {
                errorMessage = $"Modbus参数 '{Name}' 的数据长度不能为0";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Modbus数据类型枚举
        /// </summary>
        public enum ModbusDataType
        {
            /// <summary>布尔量（线圈/离散输入，对应 1 位）</summary>
            Bool,
            /// <summary>有符号 16 位整数（1 个寄存器）</summary>
            Int16,
            /// <summary>无符号 16 位整数（1 个寄存器）</summary>
            UInt16,
            /// <summary>有符号 32 位整数（2 个寄存器）</summary>
            Int32,
            /// <summary>无符号 32 位整数（2 个寄存器）</summary>
            UInt32,
            /// <summary>32 位浮点数（IEEE754，2 个寄存器）</summary>
            Float32,
            /// <summary>64 位浮点数（IEEE754，4 个寄存器）</summary>
            Double64,
            /// <summary>ASCII 字符串（多个寄存器）</summary>
            AsciiString,
        }
    }
}
