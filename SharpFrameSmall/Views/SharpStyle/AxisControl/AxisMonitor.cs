using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SharpFrameSmall.Views.SharpStyle
{
    /// <summary>
    /// 轴监控控件
    /// </summary>
    [TemplatePart(Name = "PART_AxesDataGrid",    Type = typeof(DataGrid))]
    [TemplatePart(Name = "PART_JogPositiveButton", Type = typeof(System.Windows.Controls.Primitives.ButtonBase))]
    [TemplatePart(Name = "PART_JogNegativeButton", Type = typeof(System.Windows.Controls.Primitives.ButtonBase))]
    public class AxisMonitor : Control
    {
        static AxisMonitor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AxisMonitor),
                new FrameworkPropertyMetadata(typeof(AxisMonitor)));
        }

        #region 数据依赖属性

        public static readonly DependencyProperty AxesSourceProperty =
            DependencyProperty.Register(nameof(AxesSource), typeof(IEnumerable), typeof(AxisMonitor),
                new PropertyMetadata(null));

        /// <summary>轴表数据源</summary>
        public IEnumerable AxesSource
        {
            get => (IEnumerable)GetValue(AxesSourceProperty);
            set => SetValue(AxesSourceProperty, value);
        }

        public static readonly DependencyProperty SelectedAxisProperty =
            DependencyProperty.Register(nameof(SelectedAxis), typeof(object), typeof(AxisMonitor),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>当前选中轴的 ViewModel</summary>
        public object SelectedAxis
        {
            get => GetValue(SelectedAxisProperty);
            set => SetValue(SelectedAxisProperty, value);
        }

        public static readonly DependencyProperty JogSpeedProperty =
            DependencyProperty.Register(nameof(JogSpeed), typeof(double), typeof(AxisMonitor),
                new PropertyMetadata(10.0));

        /// <summary>Jog 运动速度</summary>
        public double JogSpeed
        {
            get => (double)GetValue(JogSpeedProperty);
            set => SetValue(JogSpeedProperty, value);
        }

        public static readonly DependencyProperty MaxSpeedProperty =
            DependencyProperty.Register(nameof(MaxSpeed), typeof(double), typeof(AxisMonitor),
                new PropertyMetadata(100.0));

        /// <summary>Jog 速度的上限 默认值 100</summary>
        public double MaxSpeed
        {
            get => (double)GetValue(MaxSpeedProperty);
            set => SetValue(MaxSpeedProperty, value);
        }

        #endregion

        #region 命令依赖属性

        public static readonly DependencyProperty ServoOnCommandProperty =
            DependencyProperty.Register(nameof(ServoOnCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        /// <summary>切换伺服使能状态，CommandParameter 为当前选中轴（<see cref="SelectedAxis"/>）。</summary>
        public ICommand ServoOnCommand
        {
            get => (ICommand)GetValue(ServoOnCommandProperty);
            set => SetValue(ServoOnCommandProperty, value);
        }

        public static readonly DependencyProperty EmergencyStopCommandProperty =
            DependencyProperty.Register(nameof(EmergencyStopCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        /// <summary>触发急停，CommandParameter 为当前选中轴（<see cref="SelectedAxis"/>）。</summary>
        public ICommand EmergencyStopCommand
        {
            get => (ICommand)GetValue(EmergencyStopCommandProperty);
            set => SetValue(EmergencyStopCommandProperty, value);
        }

        public static readonly DependencyProperty AlarmResetCommandProperty =
            DependencyProperty.Register(nameof(AlarmResetCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        /// <summary>清除报警，CommandParameter 为当前选中轴（<see cref="SelectedAxis"/>）。</summary>
        public ICommand AlarmResetCommand
        {
            get => (ICommand)GetValue(AlarmResetCommandProperty);
            set => SetValue(AlarmResetCommandProperty, value);
        }

        public static readonly DependencyProperty HomeCommandProperty =
            DependencyProperty.Register(nameof(HomeCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        /// <summary>执行原点回归，CommandParameter 为当前选中轴（<see cref="SelectedAxis"/>）。</summary>
        public ICommand HomeCommand
        {
            get => (ICommand)GetValue(HomeCommandProperty);
            set => SetValue(HomeCommandProperty, value);
        }

        public static readonly DependencyProperty JogPositiveStartCommandProperty =
            DependencyProperty.Register(nameof(JogPositiveStartCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        public ICommand JogPositiveStartCommand
        {
            get => (ICommand)GetValue(JogPositiveStartCommandProperty);
            set => SetValue(JogPositiveStartCommandProperty, value);
        }

        public static readonly DependencyProperty JogPositiveStopCommandProperty =
            DependencyProperty.Register(nameof(JogPositiveStopCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        public ICommand JogPositiveStopCommand
        {
            get => (ICommand)GetValue(JogPositiveStopCommandProperty);
            set => SetValue(JogPositiveStopCommandProperty, value);
        }

        public static readonly DependencyProperty JogNegativeStartCommandProperty =
            DependencyProperty.Register(nameof(JogNegativeStartCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        public ICommand JogNegativeStartCommand
        {
            get => (ICommand)GetValue(JogNegativeStartCommandProperty);
            set => SetValue(JogNegativeStartCommandProperty, value);
        }

        public static readonly DependencyProperty JogNegativeStopCommandProperty =
            DependencyProperty.Register(nameof(JogNegativeStopCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        public ICommand JogNegativeStopCommand
        {
            get => (ICommand)GetValue(JogNegativeStopCommandProperty);
            set => SetValue(JogNegativeStopCommandProperty, value);
        }

        public static readonly DependencyProperty MoveAbsoluteCommandProperty =
            DependencyProperty.Register(nameof(MoveAbsoluteCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        /// <summary>给定目标位置绝对定位，CommandParameter 为当前选中轴（<see cref="SelectedAxis"/>)。</summary>
        public ICommand MoveAbsoluteCommand
        {
            get => (ICommand)GetValue(MoveAbsoluteCommandProperty);
            set => SetValue(MoveAbsoluteCommandProperty, value);
        }

        public static readonly DependencyProperty MoveRelativeCommandProperty =
            DependencyProperty.Register(nameof(MoveRelativeCommand), typeof(ICommand), typeof(AxisMonitor),
                new PropertyMetadata(null));
        /// <summary>相对定位，CommandParameter 为当前选中轴（<see cref="SelectedAxis"/>)。</summary>
        public ICommand MoveRelativeCommand
        {
            get => (ICommand)GetValue(MoveRelativeCommandProperty);
            set => SetValue(MoveRelativeCommandProperty, value);
        }

        public static readonly DependencyProperty TargetPositionProperty =
            DependencyProperty.Register(nameof(TargetPosition), typeof(double), typeof(AxisMonitor),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        /// <summary>绝对定位目标位置</summary>
        public double TargetPosition
        {
            get => (double)GetValue(TargetPositionProperty);
            set => SetValue(TargetPositionProperty, value);
        }

        public static readonly DependencyProperty RelativeDistanceProperty =
            DependencyProperty.Register(nameof(RelativeDistance), typeof(double), typeof(AxisMonitor),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        /// <summary>相对定位距离（正值向正方向）</summary>
        public double RelativeDistance
        {
            get => (double)GetValue(RelativeDistanceProperty);
            set => SetValue(RelativeDistanceProperty, value);
        }

        public static readonly DependencyProperty MoveSpeedProperty =
            DependencyProperty.Register(nameof(MoveSpeed), typeof(double), typeof(AxisMonitor),
                new PropertyMetadata(10.0));
        /// <summary>定位运动速度</summary>
        public double MoveSpeed
        {
            get => (double)GetValue(MoveSpeedProperty);
            set => SetValue(MoveSpeedProperty, value);
        }

        #endregion

        #region 模板应用

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_AxesDataGrid") is DataGrid dg)
            {
                dg.SelectionChanged -= DataGrid_SelectionChanged;
                dg.SelectionChanged += DataGrid_SelectionChanged;
            }

            if (GetTemplateChild("PART_JogPositiveButton") is System.Windows.Controls.Primitives.ButtonBase jogPos)
            {
                jogPos.PreviewMouseLeftButtonDown -= JogPos_Down;
                jogPos.PreviewMouseLeftButtonUp   -= JogPos_Up;
                jogPos.MouseLeave                 -= JogPos_Leave;
                jogPos.PreviewMouseLeftButtonDown += JogPos_Down;
                jogPos.PreviewMouseLeftButtonUp   += JogPos_Up;
                jogPos.MouseLeave                 += JogPos_Leave;
            }

            if (GetTemplateChild("PART_JogNegativeButton") is System.Windows.Controls.Primitives.ButtonBase jogNeg)
            {
                jogNeg.PreviewMouseLeftButtonDown -= JogNeg_Down;
                jogNeg.PreviewMouseLeftButtonUp   -= JogNeg_Up;
                jogNeg.MouseLeave                 -= JogNeg_Leave;
                jogNeg.PreviewMouseLeftButtonDown += JogNeg_Down;
                jogNeg.PreviewMouseLeftButtonUp   += JogNeg_Up;
                jogNeg.MouseLeave                 += JogNeg_Leave;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dg)
                SelectedAxis = dg.SelectedItem;
        }

        private void JogPos_Down(object sender, MouseButtonEventArgs e)
        {
            if (JogPositiveStartCommand?.CanExecute(JogSpeed) == true)
                JogPositiveStartCommand.Execute(JogSpeed);
        }

        private void JogPos_Up(object sender, MouseButtonEventArgs e)
        {
            if (JogPositiveStopCommand?.CanExecute(null) == true)
                JogPositiveStopCommand.Execute(null);
        }

        private void JogPos_Leave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) JogPos_Up(sender, null);
        }

        private void JogNeg_Down(object sender, MouseButtonEventArgs e)
        {
            if (JogNegativeStartCommand?.CanExecute(JogSpeed) == true)
                JogNegativeStartCommand.Execute(JogSpeed);
        }

        private void JogNeg_Up(object sender, MouseButtonEventArgs e)
        {
            if (JogNegativeStopCommand?.CanExecute(null) == true)
                JogNegativeStopCommand.Execute(null);
        }

        private void JogNeg_Leave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) JogNeg_Up(sender, null);
        }

        #endregion
    }
}
