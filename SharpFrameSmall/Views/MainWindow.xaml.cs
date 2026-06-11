using System.Globalization;
using System;
using System.Windows;
using System.Windows.Data;
using Prism.Events;
using System.Windows.Controls;

namespace SharpFrameSmall.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator aggregator)
        {
            InitializeComponent();
        }
    }

    public class PermissionToEnabledConverter : IValueConverter
    {
        /// <summary>
        /// value: 当前用户等级（int 或枚举）
        /// parameter: 所需最小权限等级
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;

            int currentLevel = value is Enum
                ? (int)(object)value
                : System.Convert.ToInt32(value);

            int requiredLevel = System.Convert.ToInt32(parameter);
            bool result = currentLevel >= requiredLevel;
            System.Diagnostics.Debug.WriteLine($"[PermissionConverter] current={currentLevel}, required={requiredLevel}, result={result}");

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
