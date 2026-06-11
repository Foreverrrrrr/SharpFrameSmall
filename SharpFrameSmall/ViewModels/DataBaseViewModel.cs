using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SharpFrameSmall.ViewModels
{
    public class DataBaseViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        public DataBaseViewModel(IEventAggregator aggregator, IRegionManager regionManager, IDialogService dialog)
        {
            this.regionManager = regionManager;
            this.eventAggregator = aggregator;
            this.dialogService = dialog;
            DatabaseTimeQuery = new DelegateCommand(() =>
            {

            });
            Export = new DelegateCommand<object>((obj) =>
            {
                SaveFileDialog savedialog = new SaveFileDialog
                {
                    Title = "保存Excel文件",
                    Filter = "Excel文件 (*.xlsx)|*.xlsx",
                    DefaultExt = ".xlsx",
                    FileName = $"Label_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };
                bool? result = savedialog.ShowDialog();
                if (result == true)
                {
                    string filePath = savedialog.FileName;
                    ExcelTool.WriteExcel(filePath, DatabaseView);
                }
            });
        }

        private bool _isLoading;
        /// <summary>
        /// 加载动画
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// 数据库时间查询命令
        /// </summary>
        public DelegateCommand DatabaseTimeQuery { get; set; }

        /// <summary>
        /// 数据导出Excel命令
        /// </summary>
        public DelegateCommand<object> Export { get; set; }

        private DateTime _time = DateTime.Now;

        public DateTime Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        private ObservableCollection<Data> _databaseview;

        public ObservableCollection<Data> DatabaseView
        {
            get { return _databaseview; }
            set { SetProperty(ref _databaseview, value); }
        }
    }

    public class Data
    {
        public string Time { get; set; }
        public string result { get; set; }
        public string value { get; set; }
    }
}
