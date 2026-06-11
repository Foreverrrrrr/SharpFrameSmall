using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SharpFrameSmall.Views.SharpStyle
{
    // ══════════════════════════════════════════════════════════════════════════
    // 枚举
    // ══════════════════════════════════════════════════════════════════════════

    /// <summary>轴状态枚举</summary>
    /// <summary>
    /// 轴状态枚举
    /// </summary>
    public enum AxisStatus
    {
        /// <summary>
        /// 未知状态
        /// </summary>
        Unknown,

        /// <summary>
        /// 就绪状态（轴使能）
        /// </summary>
        Ready,

        /// <summary>
        /// 运动中
        /// </summary>
        Moving,

        /// <summary>
        /// 报警状态
        /// </summary>
        Alarm,

        /// <summary>
        /// 急停状态
        /// </summary>
        EmergencyStop,

        /// <summary>
        /// 轴未使能
        /// </summary>
        Disabled
    }

    // ══════════════════════════════════════════════════════════════════════════
    // 转换器（供 AxisControl 和 AxisMonitor 共用）
    // ══════════════════════════════════════════════════════════════════════════

    /// <summary>轴状态 → 中文文字</summary>
    public class AxisStatusTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is AxisStatus s)) return "未知";
            switch (s)
            {
                case AxisStatus.Ready:         return "就绪";
                case AxisStatus.Moving:        return "运动中";
                case AxisStatus.Alarm:         return "报警";
                case AxisStatus.EmergencyStop: return "急停";
                case AxisStatus.Disabled:      return "未使能";
                default:                       return "未知";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>轴状态 → 颜色画刷</summary>
    public class AxisStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is AxisStatus s)) return new SolidColorBrush(Colors.Gray);
            switch (s)
            {
                case AxisStatus.Ready:         return new SolidColorBrush(Color.FromRgb(0x4C, 0xAF, 0x50)); // 绿
                case AxisStatus.Moving:        return new SolidColorBrush(Color.FromRgb(0x21, 0x96, 0xF3)); // 蓝
                case AxisStatus.Alarm:         return new SolidColorBrush(Color.FromRgb(0xF4, 0x43, 0x36)); // 红
                case AxisStatus.EmergencyStop: return new SolidColorBrush(Color.FromRgb(0xFF, 0x57, 0x22)); // 橙
                case AxisStatus.Disabled:      return new SolidColorBrush(Color.FromRgb(0x75, 0x75, 0x75)); // 灰
                default:                       return new SolidColorBrush(Colors.Gray);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>伺服使能状态 bool → 文字</summary>
    public class ServoOnTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return b ? "上使能" : "下使能";
            return "下使能";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>伺服使能状态 bool → 颜色画刷</summary>
    public class ServoOnColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b)
                return new SolidColorBrush(Color.FromRgb(0x2E, 0x7D, 0x32)); // 深绿
            return new SolidColorBrush(Color.FromRgb(0x15, 0x65, 0xC0));      // 蓝
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }

    /// <summary>位置 double → 格式化字符串（4位小数）</summary>
    public class PositionFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d) return d.ToString("F4", CultureInfo.InvariantCulture);
            return "0.0000";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => DependencyProperty.UnsetValue;
    }
}
