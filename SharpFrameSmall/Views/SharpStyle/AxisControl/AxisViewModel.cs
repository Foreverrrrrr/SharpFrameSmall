using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpFrameSmall.Views.SharpStyle
{
    /// <summary>
    /// 单轴数据模型，直接绑定到 <see cref="AxisMonitor.AxesSource"/>。
    /// <para>调用方无需自定义，直接实例化并放入集合即可。</para>
    /// </summary>
    public class AxisViewModel : INotifyPropertyChanged
    {
        private int _axisNo;
        /// <summary>轴号</summary>
        public int AxisNo
        {
            get => _axisNo;
            set { _axisNo = value; OnPropertyChanged(); }
        }

        private string _axisName = "Axis";
        /// <summary>轴名称</summary>
        public string AxisName
        {
            get => _axisName;
            set { _axisName = value; OnPropertyChanged(); }
        }

        private double _pulsePosition;
        /// <summary>指令脉冲位置</summary>
        public double PulsePosition
        {
            get => _pulsePosition;
            set { _pulsePosition = value; OnPropertyChanged(); }
        }

        private double _encoderPosition;
        /// <summary>编码器反馈位置</summary>
        public double EncoderPosition
        {
            get => _encoderPosition;
            set { _encoderPosition = value; OnPropertyChanged(); }
        }

        private string _positionUnit = "mm";
        /// <summary>位置单位 "mm"、"°"、"pulse"</summary>
        public string PositionUnit
        {
            get => _positionUnit;
            set { _positionUnit = value; OnPropertyChanged(); }
        }

        private bool _isServoOn;
        /// <summary>伺服使能状态（true = 已使能）</summary>
        public bool IsServoOn
        {
            get => _isServoOn;
            set { _isServoOn = value; OnPropertyChanged(); }
        }

        private AxisStatus _axisStatus = AxisStatus.Unknown;
        /// <summary>
        /// 轴当前状态。
        /// <para>设置此属性时会调用 <see cref="ResolveServoOnFromStatus"/>，默认将
        /// Ready / Moving 同步为使能，其余为未使能。子类可重写该方法以适配实际硬件行为。</para>
        /// </summary>
        public AxisStatus AxisStatus
        {
            get => _axisStatus;
            set
            {
                _axisStatus = value;
                OnPropertyChanged();
                // EmergencyStop 不改变使能状态，硬件急停后伺服保持原状态
                // 如需下使能，请在急停回调中手动设置 IsServoOn = false
                if (value != AxisStatus.EmergencyStop)
                {
                    bool servoOn = ResolveServoOnFromStatus(value);
                    if (_isServoOn != servoOn)
                    {
                        _isServoOn = servoOn;
                        OnPropertyChanged(nameof(IsServoOn));
                    }
                }
            }
        }

        /// <summary>
        /// 根据轴状态推断伺服使能状态（<see cref="AxisStatus.EmergencyStop"/> 不会进入此方法，使能状态保持不变）。
        /// <para>默认：<see cref="AxisStatus.Ready"/> / <see cref="AxisStatus.Moving"/> → true，其余 → false。</para>
        /// <para>子类可重写此方法以适配特殊硬件行为。</para>
        /// </summary>
        protected virtual bool ResolveServoOnFromStatus(AxisStatus status)
            => status == AxisStatus.Ready || status == AxisStatus.Moving;

        private bool _isHomeSensor;
        /// <summary>原点传感器信号（true = 触发）</summary>
        public bool IsHomeSensor
        {
            get => _isHomeSensor;
            set { _isHomeSensor = value; OnPropertyChanged(); }
        }

        private bool _isLimitPositive;
        /// <summary>正向限位信号（true = 触发）</summary>
        public bool IsLimitPositive
        {
            get => _isLimitPositive;
            set { _isLimitPositive = value; OnPropertyChanged(); }
        }

        private bool _isLimitNegative;
        /// <summary>负向限位信号（true = 触发）</summary>
        public bool IsLimitNegative
        {
            get => _isLimitNegative;
            set { _isLimitNegative = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
