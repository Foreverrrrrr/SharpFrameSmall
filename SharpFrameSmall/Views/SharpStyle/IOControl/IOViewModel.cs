using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SharpFrameSmall.Views.SharpStyle
{
    /// <summary>
    /// 单个 IO 点数据模型，可直接绑定到 <see cref="IOInputMonitor.PointsSource"/> 或
    /// <see cref="IOOutputMonitor.PointsSource"/>。
    /// </summary>
    public class IOPointViewModel : INotifyPropertyChanged
    {
        private int _pointNo;
        /// <summary>IO 点编号</summary>
        public int PointNo
        {
            get => _pointNo;
            set { _pointNo = value; OnPropertyChanged(); }
        }

        private string _pointName = "IO";
        /// <summary>IO 点名称</summary>
        public string PointName
        {
            get => _pointName;
            set { _pointName = value; OnPropertyChanged(); }
        }

        private bool _isActive;
        /// <summary>
        /// IO 点当前状态
        /// </summary>
        public bool IsActive
        {
            get => _isActive;
            set { _isActive = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
