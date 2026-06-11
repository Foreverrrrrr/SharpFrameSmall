using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using SharpFrameSmall.Structure.Parameter;
using ValidationResult = SharpFrameSmall.Structure.Parameter.ValidationResult;

namespace SharpFrameSmall.Views.SharpStyle
{
    /// <summary>
    /// 布尔取反转换器
    /// </summary>
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            return value;
        }
    }

    public class EditModeToReadOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ParameterEditMode mode)) return true;
            var param = parameter as string;

            bool isReadOnly;
            if (param == "ValueOnly")
                isReadOnly = mode == ParameterEditMode.ReadOnly;
            else
                isReadOnly = mode != ParameterEditMode.Full;

            if (param == "Invert")
                return mode == ParameterEditMode.Full;

            return isReadOnly;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    public class EditModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ParameterEditMode mode)) return Visibility.Collapsed;
            return mode == ParameterEditMode.Full ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    public class BindingProxy : Freezable
    {
        protected override Freezable CreateInstanceCore() => new BindingProxy();

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register(
                nameof(Data),
                typeof(object),
                typeof(BindingProxy),
                new PropertyMetadata(null));

        public object Data
        {
            get => GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
    }

    public class SafeDataGrid : DataGrid
    {
        static SafeDataGrid()
        {
            TryPatchCellCoercion();
        }

        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            var source = PresentationTraceSources.DataBindingSource;
            var saved = source.Switch.Level;
            source.Switch.Level = SourceLevels.Critical; 

            base.ClearContainerForItemOverride(element, item);
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
                new Action(() => source.Switch.Level = saved));
        }

        private static void TryPatchCellCoercion()
        {
            try
            {
                var field = typeof(PropertyMetadata).GetField("_coerceValueCallback",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (field == null) return;

                CoerceValueCallback pass = (d, v) => v;

                var fgMeta = DataGridCell.ForegroundProperty.GetMetadata(typeof(DataGridCell));
                if (fgMeta != null) field.SetValue(fgMeta, pass);

                var bbMeta = DataGridCell.BorderBrushProperty.GetMetadata(typeof(DataGridCell));
                if (bbMeta != null) field.SetValue(bbMeta, pass);
            }
            catch { /* 反射失败时忽略 */ }
        }
    }

    /// <summary>
    /// 参数编辑权限模式
    /// </summary>
    public enum ParameterEditMode
    {
        /// <summary>只读 - 不允许任何编辑</summary>
        ReadOnly,
        /// <summary>仅值编辑 - 只能修改字段的 Value，不能增删参数/字段、不能改名称/描述/字段名/类型/单位</summary>
        ValueOnly,
        /// <summary>完全编辑 - 可增删改所有内容</summary>
        Full
    }

    /// <summary>
    /// 参数数据表格自定义控件 - 支持多字段参数的可视化编辑
    /// </summary>
    public class ParameterDataGrid : Control
    {
        static ParameterDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ParameterDataGrid),
                new FrameworkPropertyMetadata(typeof(ParameterDataGrid)));
        }

        #region 依赖属性

        /// <summary>
        /// 参数数据源
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// 是否允许编辑内容
        /// </summary>
        public static readonly DependencyProperty IsContentEditableProperty =
            DependencyProperty.Register(
                nameof(IsContentEditable),
                typeof(bool),
                typeof(ParameterDataGrid),
                new PropertyMetadata(true));

        public bool IsContentEditable
        {
            get => (bool)GetValue(IsContentEditableProperty);
            set => SetValue(IsContentEditableProperty, value);
        }

        /// <summary>
        /// 编辑权限模式
        /// <para>ReadOnly=只读, ValueOnly=仅改值, Full=完全编辑</para>
        /// </summary>
        /// <example>
        /// &lt;!-- 操作员：只能改参数值 --&gt;
        /// &lt;local:ParameterDataGrid EditMode="ValueOnly" /&gt;
        /// &lt;!-- 工程师：可增删改所有 --&gt;
        /// &lt;local:ParameterDataGrid EditMode="Full" /&gt;
        /// </example>
        public static readonly DependencyProperty EditModeProperty =
            DependencyProperty.Register(
                nameof(EditMode),
                typeof(ParameterEditMode),
                typeof(ParameterDataGrid),
                new PropertyMetadata(ParameterEditMode.Full, OnEditModeChanged));

        public ParameterEditMode EditMode
        {
            get => (ParameterEditMode)GetValue(EditModeProperty);
            set => SetValue(EditModeProperty, value);
        }

        private static void OnEditModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (ParameterDataGrid)d;
            ctrl.IsContentEditable = (ParameterEditMode)e.NewValue != ParameterEditMode.ReadOnly;
            // 触发 CommandManager 重新查询所有命令的 CanExecute
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// 是否为完全编辑模式
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public bool IsFullAccessEnabled => EditMode == ParameterEditMode.Full;

        /// <summary>
        /// 是否为仅值编辑模式
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public bool IsValueOnlyMode => EditMode == ParameterEditMode.ValueOnly;

        /// <summary>
        /// 是否显示字段详情区域
        /// </summary>
        public static readonly DependencyProperty ShowFieldDetailsProperty =
            DependencyProperty.Register(
                nameof(ShowFieldDetails),
                typeof(bool),
                typeof(ParameterDataGrid),
                new PropertyMetadata(true));

        public bool ShowFieldDetails
        {
            get => (bool)GetValue(ShowFieldDetailsProperty);
            set => SetValue(ShowFieldDetailsProperty, value);
        }

        /// <summary>
        /// 标题文本
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(ParameterDataGrid),
                new PropertyMetadata("参数列表"));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// 参数仓储实例
        /// </summary>
        public static readonly DependencyProperty StoreProperty =
            DependencyProperty.Register(
                nameof(Store),
                typeof(ParameterStore),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null, OnStoreBindingChanged));

        public ParameterStore Store
        {
            get => (ParameterStore)GetValue(StoreProperty);
            set => SetValue(StoreProperty, value);
        }

        public static readonly DependencyProperty StoreKeyProperty =
            DependencyProperty.Register(
                nameof(StoreKey),
                typeof(string),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null, OnStoreBindingChanged));

        public string StoreKey
        {
            get => (string)GetValue(StoreKeyProperty);
            set => SetValue(StoreKeyProperty, value);
        }

        /// <summary>
        /// 保存完成后的回调命令
        /// </summary>
        public static readonly DependencyProperty SaveCallbackCommandProperty =
            DependencyProperty.Register(
                nameof(SaveCallbackCommand),
                typeof(ICommand),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null));

        public ICommand SaveCallbackCommand
        {
            get => (ICommand)GetValue(SaveCallbackCommandProperty);
            set => SetValue(SaveCallbackCommandProperty, value);
        }

        /// <summary>
        /// 内部保存命令
        /// </summary>
        public static readonly DependencyProperty InternalSaveCommandProperty =
            DependencyProperty.Register(
                nameof(InternalSaveCommand),
                typeof(ICommand),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null));

        public ICommand InternalSaveCommand
        {
            get => (ICommand)GetValue(InternalSaveCommandProperty);
            set => SetValue(InternalSaveCommandProperty, value);
        }

        /// <summary>
        /// 最近一次保存结果
        /// </summary>
        public static readonly DependencyProperty LastValidationResultProperty =
            DependencyProperty.Register(
                nameof(LastValidationResult),
                typeof(ValidationResult),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null));

        public ValidationResult LastValidationResult
        {
            get => (ValidationResult)GetValue(LastValidationResultProperty);
            set => SetValue(LastValidationResultProperty, value);
        }

        /// <summary>
        /// 状态栏消息文本
        /// </summary>
        public static readonly DependencyProperty StatusMessageProperty =
            DependencyProperty.Register(
                nameof(StatusMessage),
                typeof(string),
                typeof(ParameterDataGrid),
                new PropertyMetadata(null, OnStatusMessageChanged));

        public string StatusMessage
        {
            get => (string)GetValue(StatusMessageProperty);
            set => SetValue(StatusMessageProperty, value);
        }

        private static void OnStatusMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (ParameterDataGrid)d;
            ctrl.UpdateStatusBarVisibility();
        }

        /// <summary>
        /// 更新状态栏可见性
        /// </summary>
        private void UpdateStatusBarVisibility()
        {
            if (_statusBar == null) return;
            _statusBar.Visibility = string.IsNullOrEmpty(StatusMessage)
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// 状态类型：true=成功(绿色)，false=失败(红色)
        /// </summary>
        public static readonly DependencyProperty IsStatusSuccessProperty =
            DependencyProperty.Register(
                nameof(IsStatusSuccess),
                typeof(bool),
                typeof(ParameterDataGrid),
                new PropertyMetadata(true));

        public bool IsStatusSuccess
        {
            get => (bool)GetValue(IsStatusSuccessProperty);
            set => SetValue(IsStatusSuccessProperty, value);
        }

        /// <summary>
        /// 状态自动清除计时器
        /// </summary>
        private DispatcherTimer _statusTimer;

        /// <summary>
        /// 显示状态消息
        /// </summary>
        private void ShowStatus(bool success, string message, double autoHideSeconds = 5)
        {
            IsStatusSuccess = success;
            StatusMessage = message;

            if (_statusTimer == null)
            {
                _statusTimer = new DispatcherTimer();
                _statusTimer.Tick += (s, e) =>
                {
                    _statusTimer.Stop();
                    StatusMessage = null;
                };
            }

            _statusTimer.Stop();
            _statusTimer.Interval = TimeSpan.FromSeconds(autoHideSeconds);
            _statusTimer.Start();
        }

        private static void OnStoreBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (ParameterDataGrid)d;

            if (e.OldValue is ParameterStore oldStore)
                oldStore.PropertyChanged -= ctrl.OnStorePropertyChanged;
            if (e.NewValue is ParameterStore newStore)
                newStore.PropertyChanged += ctrl.OnStorePropertyChanged;

            ctrl.UpdateStoreBinding();
        }

        /// <summary>
        /// 监听 Store 属性
        /// </summary>
        private void OnStorePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ParameterStore.IsReady)
                || e.PropertyName == nameof(ParameterStore.RecipeName))
            {
                Dispatcher.BeginInvoke(new Action(() => UpdateStoreBinding()));
            }
        }

        private void UpdateStoreBinding()
        {
            if (Store == null || string.IsNullOrEmpty(StoreKey))
                return;

            if (!Store.IsReady)
                return;

            var collection = Store.GetCollectionByKey(StoreKey);
            if (collection == null)
                return;

            ItemsSource = collection;
            if (InternalSaveCommand == null)
                InternalSaveCommand = new StoreCommand(this, ExecuteSave, canAlwaysExecute: true);
        }

        #endregion

        #region 路由事件

        /// <summary>
        /// 参数选择变更事件
        /// </summary>
        public static readonly RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(SelectionChanged),
                RoutingStrategy.Bubble,
                typeof(SelectionChangedEventHandler),
                typeof(ParameterDataGrid));

        public event SelectionChangedEventHandler SelectionChanged
        {
            add => AddHandler(SelectionChangedEvent, value);
            remove => RemoveHandler(SelectionChangedEvent, value);
        }

        /// <summary>
        /// 保存完成路由事件
        /// </summary>
        public static readonly RoutedEvent SaveCompletedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(SaveCompleted),
                RoutingStrategy.Bubble,
                typeof(EventHandler<SaveCompletedEventArgs>),
                typeof(ParameterDataGrid));

        public event EventHandler<SaveCompletedEventArgs> SaveCompleted
        {
            add => AddHandler(SaveCompletedEvent, value);
            remove => RemoveHandler(SaveCompletedEvent, value);
        }

        #endregion

        #region 模板部分

        private DataGrid _dataGrid;
        private Border _statusBar;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _dataGrid = GetTemplateChild("PART_DataGrid") as DataGrid;
            _statusBar = GetTemplateChild("PART_StatusBar") as Border;

            if (_dataGrid != null)
            {
                _dataGrid.SelectionChanged += (s, e) =>
                {
                    RaiseEvent(new SelectionChangedEventArgs(
                        SelectionChangedEvent,
                        e.RemovedItems,
                        e.AddedItems));
                };
                _dataGrid.Tag = new CommandProxy(this);
            }

            AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(OnTemplateButtonClick));
            AddHandler(ToggleButton.CheckedEvent, new RoutedEventHandler(OnExpandToggle));
            AddHandler(ToggleButton.UncheckedEvent, new RoutedEventHandler(OnExpandToggle));

            UpdateStatusBarVisibility();
            UpdateStoreBinding();
        }

        /// <summary>
        /// 处理模板内按钮点击（添加 / 删除）
        /// </summary>
        private void OnTemplateButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is Button button)) return;

            if (button.Name == "DismissStatusButton")
            {
                StatusMessage = null;
            }
            else if (button.Name == "AddFieldButton")
            {
                if (!IsFullAccessEnabled) return;
                var parameter = FindDataContext<ParameterBase>(button);
                if (parameter != null)
                {
                    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
                        new Action(() => parameter.AddField($"Field{parameter.FieldCount + 1}", "", unit: "", description: "")));
                }
            }
            else if (button.Name == "RemoveFieldButton")
            {
                if (!IsFullAccessEnabled) return;
                if (button.DataContext is ParameterField field)
                {
                    var parameter = FindOwnerParameter(button);
                    if (parameter != null && parameter.Fields.Contains(field))
                    {
                        Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
                            new Action(() => parameter.Fields.Remove(field)));
                    }
                }
            }
        }

        /// <summary>
        /// 处理展开/折叠切换
        /// </summary>
        private void OnExpandToggle(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is ToggleButton toggle)) return;
            if (toggle.Name != "ExpandToggle") return;

            var row = FindParent<DataGridRow>(toggle);
            if (row != null)
            {
                row.DetailsVisibility = toggle.IsChecked == true
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 获取当前选中的参数项
        /// </summary>
        public object SelectedItem => _dataGrid?.SelectedItem;

        /// <summary>
        /// 获取当前选中的参数项索引
        /// </summary>
        public int SelectedIndex => _dataGrid?.SelectedIndex ?? -1;

        /// <summary>
        /// 提交编辑 + 清除选中
        /// </summary>
        private void PrepareForCollectionChange()
        {
            if (_dataGrid != null)
            {
                _dataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                _dataGrid.UnselectAll();
            }
        }

        #endregion

        #region 内置 CRUD 操作

        /// <summary>
        /// 向前添加参数
        /// </summary>
        private static void ExecuteAddForward(ParameterDataGrid owner, object parameter)
        {
            if (!owner.IsFullAccessEnabled) return;
            if (owner.Store == null || string.IsNullOrEmpty(owner.StoreKey)) return;

            var collection = owner.Store.GetCollectionByKey(owner.StoreKey);
            var newParam = owner.Store.CreateParameter(owner.StoreKey);

            if (parameter is ParameterBase selected)
            {
                int idx = collection.IndexOf(selected);
                if (idx >= 0)
                {
                    collection.Insert(idx, newParam);
                    return;
                }
            }
            collection.Insert(0, newParam);
        }

        /// <summary>
        /// 向后添加参数
        /// </summary>
        private static void ExecuteAddBackward(ParameterDataGrid owner, object parameter)
        {
            if (!owner.IsFullAccessEnabled) return;
            if (owner.Store == null || string.IsNullOrEmpty(owner.StoreKey)) return;

            var collection = owner.Store.GetCollectionByKey(owner.StoreKey);
            var newParam = owner.Store.CreateParameter(owner.StoreKey);

            if (parameter is ParameterBase selected)
            {
                int idx = collection.IndexOf(selected);
                if (idx >= 0)
                {
                    collection.Insert(idx + 1, newParam);
                    return;
                }
            }
            collection.Add(newParam);
        }

        /// <summary>
        /// 删除参数
        /// </summary>
        private static void ExecuteRemove(ParameterDataGrid owner, object parameter)
        {
            if (!owner.IsFullAccessEnabled) return;
            if (owner.Store == null || string.IsNullOrEmpty(owner.StoreKey)) return;

            var collection = owner.Store.GetCollectionByKey(owner.StoreKey);
            if (parameter is ParameterBase selected)
            {
                collection.Remove(selected);
            }
        }

        /// <summary>
        /// 排序参数 ID 升序
        /// </summary>
        private static void ExecuteSort(ParameterDataGrid owner, object parameter)
        {
            if (owner.Store == null || string.IsNullOrEmpty(owner.StoreKey)) return;

            var collection = owner.Store.GetCollectionByKey(owner.StoreKey);
            var sorted = collection.Cast<ParameterBase>().OrderBy(p => p.ID).ToList();

            collection.Clear();
            foreach (var item in sorted)
                collection.Add(item);
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        private static void ExecuteSave(ParameterDataGrid owner, object parameter)
        {
            if (owner.Store == null || string.IsNullOrEmpty(owner.StoreKey)) return;

            ValidationResult result;
            bool success = owner.Store.SaveByKeyWithValidation(owner.StoreKey, out result);
            owner.LastValidationResult = result;

            var time = DateTime.Now.ToString("HH:mm:ss");
            if (success)
            {
                owner.ShowStatus(true, $"[{time}] 保存成功");
            }
            else
            {
                var errors = result.AllErrors;
                var brief = errors.Count <= 3
                    ? string.Join("；", errors)
                    : string.Join("；", errors.Take(3)) + $"… 共 {errors.Count} 个错误";
                owner.ShowStatus(false, $"[{time}] 保存失败 — {brief}", autoHideSeconds: 10);
            }

            owner.RaiseEvent(new SaveCompletedEventArgs(SaveCompletedEvent, success, result));

            if (success && owner.SaveCallbackCommand != null
                && owner.SaveCallbackCommand.CanExecute(owner.Store))
            {
                owner.SaveCallbackCommand.Execute(owner.Store);
            }
        }

        #endregion

        #region 辅助方法

        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is T target) return target;
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private static T FindDataContext<T>(DependencyObject element) where T : class
        {
            var current = element;
            while (current != null)
            {
                if (current is FrameworkElement fe && fe.DataContext is T dc)
                    return dc;
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        private static ParameterBase FindOwnerParameter(DependencyObject element)
        {
            var current = VisualTreeHelper.GetParent(element);
            while (current != null)
            {
                if (current is FrameworkElement fe && fe.DataContext is ParameterBase param)
                    return param;
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        #endregion

        #region 内部类

        /// <summary>
        /// Store 命令
        /// </summary>
        private class StoreCommand : ICommand
        {
            private readonly ParameterDataGrid _owner;
            private readonly Action<ParameterDataGrid, object> _execute;
            private readonly bool _canAlwaysExecute;

            public StoreCommand(ParameterDataGrid owner, Action<ParameterDataGrid, object> execute, bool canAlwaysExecute = false)
            {
                _owner = owner;
                _execute = execute;
                _canAlwaysExecute = canAlwaysExecute;
            }

            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public bool CanExecute(object parameter)
            {
                if (_canAlwaysExecute) return true;
                return _owner.Store != null && !string.IsNullOrEmpty(_owner.StoreKey) && _owner.IsFullAccessEnabled;
            }

            public void Execute(object parameter)
            {
                _owner.PrepareForCollectionChange();

                _owner.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.Background,
                    new Action(() => _execute(_owner, parameter)));
            }
        }

        /// <summary>
        /// 命令代理
        /// </summary>
        private class CommandProxy
        {
            public CommandProxy(ParameterDataGrid owner)
            {
                ParameterAddForwardCommand = new StoreCommand(owner, ExecuteAddForward);
                ParameterAddBackwardCommand = new StoreCommand(owner, ExecuteAddBackward);
                ParameterSortCommand = new StoreCommand(owner, ExecuteSort);
                ParameterRemoveCommand = new StoreCommand(owner, ExecuteRemove);
                SaveCommand = new StoreCommand(owner, ExecuteSave, canAlwaysExecute: true);
            }

            public ICommand ParameterAddForwardCommand { get; }
            public ICommand ParameterAddBackwardCommand { get; }
            public ICommand ParameterSortCommand { get; }
            public ICommand ParameterRemoveCommand { get; }
            public ICommand SaveCommand { get; }
        }

        #endregion
    }

    /// <summary>
    /// 保存完成事件参数
    /// </summary>
    public class SaveCompletedEventArgs : RoutedEventArgs
    {
        public bool IsSuccess { get; }
        public ValidationResult Result { get; }

        public SaveCompletedEventArgs(RoutedEvent routedEvent, bool isSuccess, ValidationResult result)
            : base(routedEvent)
        {
            IsSuccess = isSuccess;
            Result = result;
        }
    }
}
