using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common;
using SharpFrameSmall.log4Net;
using SharpFrameSmall.Structure.Parameter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static SharpFrameSmall.Common.ExcelTool;

namespace SharpFrameSmall.ViewModels
{
    /// <summary>
    /// 通用 Excel 数据对话框 ViewModel
    /// 通过 DialogParameters 中的 DataType 参数适配 ErrorCode / Label / Esop 等任意数据类型
    /// </summary>
    public class ErrorCodeDialogViewModel : BindableBase, IDialogAware
    {
        private readonly IEventAggregator eventAggregator;
        private IExcelDialogHelper _helper;
        private Type _dataType;
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public ErrorCodeDialogViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSave);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        #region 绑定属性

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private string _title = "Excel Data";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private IEnumerable _dataSource;
        /// <summary>
        /// DataGrid 数据源 — 运行时为 ObservableCollection&lt;T&gt;，
        /// AutoGenerateColumns 会自动根据实际泛型类型生成列
        /// </summary>
        public IEnumerable DataSource
        {
            get => _dataSource;
            set => SetProperty(ref _dataSource, value);
        }
        #endregion

        public string ExcelPath { get; set; }
        public string Table { get; set; }
        public event Action<IDialogResult> RequestClose;
        public bool CanCloseDialog() => true;
        public void OnDialogClosed() { }
        private void OnSave()
        {
            if (_helper == null) return;
            int changedCount = _helper.GetChangedCount();
            if (changedCount == 0)
            {
                MessageBox.Show("沒有檢測到數據變更", "Prompt", MessageBoxButton.OK);
                return;
            }
            var descriptions = _helper.GetChangeDescriptions();
            foreach (var desc in descriptions)
            {
                eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                {
                    Time = DateTime.Now.ToString(),
                    Value = $"[{ExcelPath}] [{Table}] {desc}"
                });
            }
            var t = MessageBox.Show(
                $"已檢測到 {changedCount} 條數據發生了變化，是否需要進行更新呢？",
                "Prompt",
                MessageBoxButton.YesNo);
            if (t == MessageBoxResult.Yes)
            {
                bool success = _helper.ApplyUpdates(ExcelPath, Table);
                eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                {
                    Time = DateTime.Now.ToString(),
                    Value = success
                        ? $"[{ExcelPath}] [{Table}] 數據更新完成，共更新 {changedCount} 條"
                        : $"[{ExcelPath}] [{Table}] 數據更新失敗"
                });
                if (success)
                {
                    IDialogParameters parameters = new DialogParameters();
                    parameters.Add("obj", _helper.GetDisplayCollection());
                    parameters.Add("DataType", _dataType);
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameters));
                }
            }
        }

        private void OnCancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Task.Run(async () =>
            {
                IsLoading = true;
                ExcelPath = parameters.GetValue<string>("Path");
                Table = parameters.GetValue<string>("Table");
                _dataType = parameters.GetValue<Type>("DataType");
                if (string.IsNullOrWhiteSpace(ExcelPath) || string.IsNullOrWhiteSpace(Table) || _dataType == null)
                {
                    App.Current.Dispatcher.Invoke(() =>
                        MessageBox.Show("對話框參數不完整（Path / Table / DataType）", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                    IsLoading = false;
                    return;
                }
                string fullPath = Path.GetFullPath(ExcelPath);
                Title = fullPath + "   Table：" + Table;
                _helper = ExcelDialogHelperFactory.Create(_dataType);
                _helper.LoadData(ExcelPath, Table);
                App.Current.Dispatcher.Invoke(() =>
                {
                    DataSource = _helper.GetDisplayCollection();
                });
                await Task.Delay(300);
                IsLoading = false;
            });
        }
    }
}
