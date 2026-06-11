using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SharpFrameSmall.Views.SharpStyle
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Notification_Popu"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Notification_Popu;assembly=Notification_Popu"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:SuspensionNotice/>
    ///
    /// </summary>
    public class GenericNotification : Control
    {
        static GenericNotification()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GenericNotification), new FrameworkPropertyMetadata(typeof(GenericNotification)));
        }

        public static readonly DependencyProperty IsNoticeProperty =
            DependencyProperty.Register("IsNotice", typeof(ObservableCollection<NotificationModel>), typeof(GenericNotification), new PropertyMetadata(null, OnIsNoticeChanged));

        public ObservableCollection<NotificationModel> IsNotice
        {
            get { return (ObservableCollection<NotificationModel>)GetValue(IsNoticeProperty); }
            set { SetValue(IsNoticeProperty, value); }
        }

        public GenericNotification()
        {
            // 每个实例创建自己的集合，避免 DependencyProperty 默认值共享问题
            SetCurrentValue(IsNoticeProperty, new ObservableCollection<NotificationModel>());
        }

        private static void OnIsNoticeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (GenericNotification)d;

            // 取消旧集合的事件订阅
            if (e.OldValue is ObservableCollection<NotificationModel> oldCollection)
            {
                oldCollection.CollectionChanged -= control.OnNoticeCollectionChanged;
            }

            // 订阅新集合的事件
            if (e.NewValue is ObservableCollection<NotificationModel> newCollection)
            {
                newCollection.CollectionChanged += control.OnNoticeCollectionChanged;
            }

            control.UpdateNotifications();
        }

        private void OnNoticeCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // 当通知被移除时，停止其定时器防止泄漏
            if (e.OldItems != null)
            {
                foreach (NotificationModel item in e.OldItems)
                {
                    item.StopAutoRemoveTimer();
                }
            }
        }

        private void UpdateNotifications()
        {
            // 这里可以根据 IsNotice 集合的内容更新通知显示
            // 暂时省略具体实现，后续会在模板中处理
        }
    }
}
