using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SharpFrameSmall.Views.SharpStyle
{

    /// <summary>IO 激活状态 bool → 指示灯颜色画刷</summary>
    public class IOActiveColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return new SolidColorBrush(Color.FromRgb(0x4C, 0xAF, 0x50)); // 绿 — ON
            return new SolidColorBrush(Color.FromRgb(0x42, 0x42, 0x42));      // 暗灰 — OFF
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>IO 激活状态 bool → 状态文字</summary>
    public class IOActiveTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return b ? "ON" : "OFF";
            return "OFF";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>IO 激活状态 bool → 输出按钮文字（用于 IOOutputMonitor）</summary>
    public class IOOutputButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return b ? "置 OFF" : "置 ON";
            return "置 ON";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>IO 激活状态 bool → 输出按钮背景色</summary>
    public class IOOutputButtonColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return new SolidColorBrush(Color.FromRgb(0xC6, 0x28, 0x28)); // 深红 — 置OFF
            return new SolidColorBrush(Color.FromRgb(0x2E, 0x7D, 0x32));      // 深绿 — 置ON
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>
    /// IO 输入状态监控控件，以列表形式只读显示各 IO 点的激活状态。
    /// <para>绑定 <see cref="PointsSource"/> 到 <see cref="IOPointViewModel"/> 集合即可使用。</para>
    /// </summary>
    public class IOInputMonitor : Control
    {
        static IOInputMonitor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(IOInputMonitor),
                new FrameworkPropertyMetadata(typeof(IOInputMonitor)));
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(IOInputMonitor),
                new PropertyMetadata("DI — 输入状态"));

        /// <summary>卡片标题</summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty PointsSourceProperty =
            DependencyProperty.Register(nameof(PointsSource), typeof(IEnumerable), typeof(IOInputMonitor),
                new PropertyMetadata(null));

        /// <summary>IO 输入点数据源（<see cref="IOPointViewModel"/> 集合）</summary>
        public IEnumerable PointsSource
        {
            get => (IEnumerable)GetValue(PointsSourceProperty);
            set => SetValue(PointsSourceProperty, value);
        }

    }

    /// <summary>
    /// IO 输出状态显示与控制控件，以列表形式显示各 IO 点状态，并提供切换按钮。
    /// <para>绑定 <see cref="PointsSource"/> 到 <see cref="IOPointViewModel"/> 集合，
    /// 绑定 <see cref="ToggleOutputCommand"/> 到切换输出的命令（CommandParameter 为目标 <see cref="IOPointViewModel"/>）。</para>
    /// </summary>
    public class IOOutputMonitor : Control
    {
        static IOOutputMonitor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(IOOutputMonitor),
                new FrameworkPropertyMetadata(typeof(IOOutputMonitor)));
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(IOOutputMonitor),
                new PropertyMetadata("DO — 输出控制"));

        /// <summary>卡片标题</summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty PointsSourceProperty =
            DependencyProperty.Register(nameof(PointsSource), typeof(IEnumerable), typeof(IOOutputMonitor),
                new PropertyMetadata(null));

        /// <summary>IO 输出点数据源（<see cref="IOPointViewModel"/> 集合）</summary>
        public IEnumerable PointsSource
        {
            get => (IEnumerable)GetValue(PointsSourceProperty);
            set => SetValue(PointsSourceProperty, value);
        }

        public static readonly DependencyProperty ToggleOutputCommandProperty =
            DependencyProperty.Register(nameof(ToggleOutputCommand), typeof(ICommand), typeof(IOOutputMonitor),
                new PropertyMetadata(null));

        /// <summary>
        /// 切换 IO 输出状态命令，CommandParameter 为对应的 <see cref="IOPointViewModel"/>。
        /// </summary>
        public ICommand ToggleOutputCommand
        {
            get => (ICommand)GetValue(ToggleOutputCommandProperty);
            set => SetValue(ToggleOutputCommandProperty, value);
        }

        public static readonly DependencyProperty IsOperationEnabledProperty =
            DependencyProperty.Register(nameof(IsOperationEnabled), typeof(bool), typeof(IOOutputMonitor),
                new PropertyMetadata(true));

        /// <summary>是否允许切换输出，默认 true。设为 false 时所有切换按钮禁用。</summary>
        public bool IsOperationEnabled
        {
            get => (bool)GetValue(IsOperationEnabledProperty);
            set => SetValue(IsOperationEnabledProperty, value);
        }
    }
}
