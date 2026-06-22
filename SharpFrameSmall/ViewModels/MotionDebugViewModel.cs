using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common.Commumication;
using SharpFrameSmall.Views.SharpStyle;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace SharpFrameSmall.ViewModels
{
    public class MotionDebugViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        public ObservableCollection<AxisViewModel> Axes { get; set; } = new ObservableCollection<AxisViewModel>();

        private AxisViewModel _selectedAxis;
        public AxisViewModel SelectedAxis
        {
            get => _selectedAxis;
            set => SetProperty(ref _selectedAxis, value);
        }

        private double _jogSpeed = 10.0;
        public double JogSpeed
        {
            get => _jogSpeed;
            set => SetProperty(ref _jogSpeed, value);
        }

        private double _targetPosition = 0.0;
        public double TargetPosition
        {
            get => _targetPosition;
            set => SetProperty(ref _targetPosition, value);
        }

        private double _relativeDistance = 0.0;
        public double RelativeDistance
        {
            get => _relativeDistance;
            set => SetProperty(ref _relativeDistance, value);
        }

        private double _moveSpeed = 0.0;
        public double MoveSpeed
        {
            get => _moveSpeed;
            set => SetProperty(ref _moveSpeed, value);
        }

        public DelegateCommand<AxisViewModel> ServoOnCommand { get; set; }
        public DelegateCommand<AxisViewModel> EStopCommand { get; set; }
        public DelegateCommand<AxisViewModel> AlarmResetCommand { get; set; }
        public DelegateCommand<AxisViewModel> HomeCommand { get; set; }
        public DelegateCommand<object> JogPosStartCommand { get; set; }
        public DelegateCommand<object> JogPosStopCommand { get; set; }
        public DelegateCommand<object> JogNegStartCommand { get; set; }
        public DelegateCommand<object> JogNegStopCommand { get; set; }
        public DelegateCommand<AxisViewModel> MoveAbsCommand { get; }
        public DelegateCommand<AxisViewModel> MoveRelCommand { get; }

        private readonly DispatcherTimer _refreshTimer;

        public ObservableCollection<IOPointViewModel> DiPoints { get; } = new ObservableCollection<IOPointViewModel>
    {
        new IOPointViewModel { PointNo = 0, PointName = "载具伸出气缸前限位"},
        new IOPointViewModel { PointNo = 1, PointName = "气缸后限位"},
        new IOPointViewModel { PointNo = 2, PointName = "夹具到位"},
        new IOPointViewModel { PointNo = 3, PointName = "安全门关闭"},
    };

        public ObservableCollection<IOPointViewModel> DoPoints { get; } = new ObservableCollection<IOPointViewModel>
    {
        new IOPointViewModel { PointNo = 0, PointName = "载具伸出气缸前限位"},
        new IOPointViewModel { PointNo = 1, PointName = "夹具夹紧"},
        new IOPointViewModel { PointNo = 2, PointName = "警示灯",},
        new IOPointViewModel { PointNo = 3, PointName = "蜂鸣器"},
    };

        private bool _isManualMode = true;
        public bool IsManualMode
        {
            get => _isManualMode;
            set => SetProperty(ref _isManualMode, value);
        }

        public DelegateCommand<IOPointViewModel> ToggleDoCommand { get; set; }

        public MotionDebugViewModel(
            IEventAggregator aggregator,
            IRegionManager regionManager,
            IDialogService dialog,
            AsyncSharpTcpClient sharpTcpClient,
            AsyncSharpTcpServer tcpServer)
        {
            this.regionManager = regionManager;
            this.eventAggregator = aggregator;
            this.dialogService = dialog;

            eventAggregator.GetEvent<PageLoadEvent>().Subscribe((classobj) =>
            {
            }, ThreadOption.UIThread);
            Axes.Add(new AxisViewModel { AxisNo = 0, AxisName = "X", PositionUnit = "mm", AxisStatus = AxisStatus.Ready });
            Axes.Add(new AxisViewModel { AxisNo = 1, AxisName = "Y", PositionUnit = "mm", AxisStatus = AxisStatus.Ready });
            Axes.Add(new AxisViewModel { AxisNo = 2, AxisName = "Z", PositionUnit = "°", AxisStatus = AxisStatus.Disabled });

            ServoOnCommand = new DelegateCommand<AxisViewModel>(axis =>
            {
                if (axis == null) return;
                axis.IsServoOn = !axis.IsServoOn;
                axis.AxisStatus = axis.IsServoOn ? AxisStatus.Ready : AxisStatus.Disabled;
            });

            EStopCommand = new DelegateCommand<AxisViewModel>(axis =>
            {
                if (axis == null) return;
                axis.AxisStatus = AxisStatus.EmergencyStop;
            });

            AlarmResetCommand = new DelegateCommand<AxisViewModel>(axis =>
            {
                if (axis == null) return;
                axis.AxisStatus = AxisStatus.Ready;
            });

            HomeCommand = new DelegateCommand<AxisViewModel>(axis =>
            {
                if (axis == null) return;
                axis.AxisStatus = AxisStatus.Moving;
            });

            JogPosStartCommand = new DelegateCommand<object>(param =>
            {
                double speed = param is double d ? d : JogSpeed;
                if (SelectedAxis == null) return;
                SelectedAxis.AxisStatus = AxisStatus.Moving;
            });

            JogPosStopCommand = new DelegateCommand<object>(_ =>
            {
                if (SelectedAxis == null) return;
                SelectedAxis.AxisStatus = AxisStatus.Ready;
            });

            JogNegStartCommand = new DelegateCommand<object>(param =>
            {
                double speed = param is double d ? d : JogSpeed;
                if (SelectedAxis == null) return;
                SelectedAxis.AxisStatus = AxisStatus.Moving;
            });

            JogNegStopCommand = new DelegateCommand<object>(_ =>
            {
                if (SelectedAxis == null) return;
                SelectedAxis.AxisStatus = AxisStatus.Ready;
            });
            MoveAbsCommand = new DelegateCommand<AxisViewModel>((axis) =>
            {

            });
            MoveRelCommand = new DelegateCommand<AxisViewModel>((axis) =>
            {

            });
            _refreshTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            _refreshTimer.Tick += RefreshPositions;
            _refreshTimer.Start();
            ToggleDoCommand = new DelegateCommand<IOPointViewModel>((io) =>
            {
                io.IsActive = !io.IsActive;
            });
        }

        private void RefreshPositions(object sender, EventArgs e)
        {
            foreach (var axis in Axes)
            {
                // 替换为实际 API 读取
                // axis.PulsePosition   = MotionController.GetPulsePosition(axis.AxisName);
                // axis.EncoderPosition = MotionController.GetEncoderPosition(axis.AxisName);
                // axis.AxisStatus      = MotionController.GetStatus(axis.AxisName);
            }
        }
    }
}
