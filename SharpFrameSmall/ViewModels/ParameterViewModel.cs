using ImTools;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common;
using SharpFrameSmall.Common.Commumication;
using SharpFrameSmall.log4Net;
using SharpFrameSmall.Logic.Base;
using SharpFrameSmall.LogsFolder;
using SharpFrameSmall.Structure.Parameter;
using SharpFrameSmall.ViewModels.Structure;
using SharpFrameSmall.Views.SharpStyle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using static SharpFrameSmall.ViewModels.SystemLogInViewModel;
using SystemParameter = SharpFrameSmall.Structure.Parameter.SystemParameter;

namespace SharpFrameSmall.ViewModels
{
    public class ParameterViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private int _parameterindexes = 0;
        /// <summary>
        /// 参数型号选择ComboBox
        /// </summary>
        public int ParameterIndexes
        {
            get { return _parameterindexes; }
            set { SetProperty(ref _parameterindexes, value); ModelSwitching.Execute(); }
        }

        private ObservableCollection<ComboxList> _parameterNameList = new ObservableCollection<ComboxList>();
        /// <summary>
        /// 参数型号选择集合
        /// </summary>
        public ObservableCollection<ComboxList> ParameterNameList
        {
            get { return _parameterNameList; }
            set { SetProperty(ref _parameterNameList, value); }
        }

        /// <summary>
        /// 新建参数
        /// </summary>
        public DelegateCommand NewModel { get; set; }

        public DelegateCommand Revamp { get; set; }

        public DelegateCommand Remove { get; set; }

        /// <summary>
        /// 型号切换DropDownClosed命令
        /// </summary>
        public DelegateCommand ModelSwitching { get; set; }

        /// <summary>
        /// 参数删除
        /// </summary>
        public DelegateCommand ParameterDelete { get; set; }

        /// <summary>
        /// 打开报警定义表
        /// </summary>
        public DelegateCommand OpenErrorCode { get; set; }

        /// <summary>
        /// 参数保存回调
        /// </summary>
        public DelegateCommand<ParameterStore> ParameterStoreSaveCommand { get; set; }

        private ParameterStore _store;
        public ParameterStore Store
        {
            get { return _store; }
            set { _store = value; RaisePropertyChanged(); }
        }

        private ParameterEditMode _systemEditMode;

        public ParameterEditMode SystemEditMode
        {
            get { return _systemEditMode; }
            set { _systemEditMode = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 当前参数名称
        /// </summary>
        public string ParameterName { get; set; }

        private UserLevel _currentuserlevel;

        public UserLevel CurrentUserLevel
        {
            get { return _currentuserlevel; }
            set { _currentuserlevel = value; RaisePropertyChanged(); }
        }

        public bool IsUpdatingParameterList { get; set; }

        public ParameterViewModel(
            IEventAggregator aggregator, 
            IRegionManager regionManager, 
            IDialogService dialog, 
            AsyncSharpTcpClient sharpTcpClient, 
            AsyncSharpTcpServer tcpServer)
        {
            this.regionManager = regionManager;
            this.eventAggregator = aggregator;
            this.dialogService = dialog;
            sharpTcpClient.SuccessfuConnectEvent += (ip, port) =>
            {
                eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure() { Time = DateTime.Now.ToString(), Level = "正常", Value = $"已连接至服务器 {ip}:{port}" });
                eventAggregator.GetEvent<Notification>().Publish(new Notification() { Type = Notification.InfoType.Info, Message = $"已连接至服务器 {ip}:{port}" });
            };
            sharpTcpClient.DisconnectionEvent += ((ip, port) =>
            {
                eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure() { Time = DateTime.Now.ToString(), Level = "异常", Value = $"已断开与服务器 {ip}:{port} 的连接" });
                eventAggregator.GetEvent<Notification>().Publish(new Notification() { Type = Notification.InfoType.Error, Message = $"已断开与服务器 {ip}:{port} 的连接" });
            });
            eventAggregator.GetEvent<LoginPermission>().Subscribe((type) =>
            {
                CurrentUserLevel = type.Level;
                if (type.Level < UserLevel.Admin)
                    SystemEditMode = ParameterEditMode.ReadOnly;
                else
                    SystemEditMode = ParameterEditMode.Full;
            });
            eventAggregator.GetEvent<PageLoadEvent>().Subscribe((classobj) =>
            {
                List<string> system_list = classobj[0] as List<string>;
                string paramValue = ParameterConfig.GetValue("ParameterName");
                if (system_list != null && system_list.Count != 0)
                {
                    if (system_list.Count > 0)
                    {
                        for (int i = 0; i < system_list.Count; i++)
                            ParameterNameList.Add(new ComboxList { ID = i, Name = system_list[i] });

                        ParameterName = paramValue;
                        Store = new ParameterStore(paramValue);
                        Store.Register<SystemParameter>("System", () => new List<SystemParameter>{
                            new SystemParameter(1, "波特率", 9600),
                            new SystemParameter(2, "超时时间", 3000),
                            new SystemParameter(3, "通讯端口", "COM1"),
                        });
                        Store.Register<LabelParameter>("Label", () => new List<LabelParameter>{
                            new LabelParameter(1, "默认标签",
                            new ParameterField("Content", "Hello"),
                            new ParameterField("FontSize", 12, "pt")),
                        });

                        Store.Register<AttdefParameter>("Attdef");
                        Store.Register<ModbusParameter>("Modbus");
                        bool isExisting = Store.LoadOrCreateDefaults();
                        Store.Ready();
                    }
                }
                else
                {
                    Store = new ParameterStore(paramValue);
                    Store.Register<SystemParameter>("System", () => new List<SystemParameter>{
                            new SystemParameter(1, "波特率", 9600),
                            new SystemParameter(2, "超时时间", 3000),
                            new SystemParameter(3, "通讯端口", "COM1"),
                        });
                    Store.Register<LabelParameter>("Label", () => new List<LabelParameter>{
                            new LabelParameter(1, "默认标签",
                            new ParameterField("Content", "Hello"),
                            new ParameterField("FontSize", 12, "pt")),
                        });

                    Store.Register<AttdefParameter>("Attdef");
                    Store.Register<ModbusParameter>("Modbus");
                    bool isExisting = Store.LoadOrCreateDefaults();
                    Store.Ready();
                }
                eventAggregator.GetEvent<ParameterUpdateEvent>().Publish(Store);
                
            }, ThreadOption.UIThread);
            eventAggregator.GetEvent<Close_MessageEvent>().Subscribe(() =>
            {
                sharpTcpClient.Close();
            });
            eventAggregator.GetEvent<ParameterNameListUpdateEvent>().Subscribe((nams) =>
            {
                IsUpdatingParameterList = true;
                ParameterNameList.Clear();
                for (int i = 0; i < nams.Count; i++)
                    ParameterNameList.Add(new ComboxList { ID = i, Name = nams[i] });
                if (nams.Contains(ParameterName))
                {
                    int idx = nams.FindIndex(x => x == ParameterName);
                    ParameterIndexes = idx >= 0 ? idx : 0;
                    ParameterName = nams[ParameterIndexes];
                }
                else
                {
                    ParameterIndexes = 0;
                    ParameterName = nams[ParameterIndexes];
                }
                IsUpdatingParameterList = false;
            });
            ModelSwitching = new DelegateCommand(() =>
            {
                if (IsUpdatingParameterList) return;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var stortlist = ParameterJsonTool.GetRecipeNames();
                if (ParameterIndexes < 0 || ParameterIndexes >= stortlist.Count)
                    return;
                Store.SwitchRecipe(stortlist[ParameterIndexes]);
                Store.Ready();
                eventAggregator.GetEvent<ParameterUpdateEvent>().Publish(Store);
                stopwatch.Stop();
                eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure() 
                { 
                    Time = DateTime.Now.ToString(), 
                    Value = $"参数{stortlist[ParameterIndexes]}切换完成 ({stopwatch.ElapsedMilliseconds}ms)" 
                });
            });
            NewModel = new DelegateCommand(() =>
            {
                IDialogParameters dialogParameters = new DialogParameters();
                dialogParameters.Add("Names", ParameterJsonTool.GetRecipeNames());
                dialog.ShowDialog("NewFormulaDialog", dialogParameters, (result) =>
                {
                    if (result.Result == ButtonResult.OK)
                    {
                        string customData = result.Parameters.GetValue<string>("NewName");
                        string copyData = result.Parameters.GetValue<string>("CopyName");
                        ParameterJsonTool.CopyRecipe(copyData, customData);
                        aggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                        {
                            Time = DateTime.Now.ToString(),
                            Value = $"Added new formula \"{customData}\" from \"{copyData}\"!"
                        });
                        eventAggregator.GetEvent<ParameterNameListUpdateEvent>().Publish(ParameterJsonTool.GetRecipeNames());
                    }
                });
            });
            ParameterStoreSaveCommand = new DelegateCommand<ParameterStore>((x) =>
            {
                eventAggregator.GetEvent<ParameterUpdateEvent>().Publish(x);
            });
            eventAggregator.GetEvent<ParameterUpdateEvent>().Subscribe((x) =>
            {
                ProcessBase.SetShared(x);
                ProcessBase.GetShared();
            });
            Remove = new DelegateCommand(() =>
            {
                if (System.Windows.MessageBox.Show($"Are you sure to delete formula \"{ParameterName}\"?",
                                "Confirm Delete",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ParameterJsonTool.DeleteTable(ParameterName);
                    aggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                    {
                        Time = DateTime.Now.ToString(),
                        Level = "警告",
                        Value = $"Deleted formula \"{ParameterName}\"!"
                    });
                    aggregator.GetEvent<ParameterNameListUpdateEvent>().Publish(ParameterJsonTool.GetRecipeNames());
                }
            });
            OpenErrorCode = new DelegateCommand(() =>
            {
                var t1 = Store.QueryByName<SystemParameter>("Error配置文件路径");
                t1.TryGetFieldValue("Path", out string path);
                t1.TryGetFieldValue("TableName", out string tablename);
                IDialogParameters dialogParameters = new DialogParameters();
                dialogParameters.Add("Path", path);
                dialogParameters.Add("Table", tablename);
                dialogParameters.Add("DataType", typeof(ErrorCode));
                dialog.ShowDialog("ExcelDataDialog", dialogParameters, (result) =>
                {
                    if (result.Result == ButtonResult.OK)
                    {
                        var obsKeys = result.Parameters.GetValue<ObservableCollection<ErrorCode>>("obj");
                        var keys = obsKeys?.ToList() ?? new List<ErrorCode>();
                        ExcelTool.ReadExcelData(path, tablename, ref keys);
                        //QueryCalculation.errorCodes = keys;
                       // modbustcp.Error_queueNew(QueryCalculation.errorCodes);
                    }
                });
            });
        }
    }

    public struct ComboxList
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    /// <summary>
    /// 参数更新通知
    /// </summary>
    public class ParameterUpdateEvent : PubSubEvent<ParameterStore> { }
    /// <summary>
    /// 配方增加、删除通知
    /// </summary>
    public class ParameterNameListUpdateEvent : PubSubEvent<List<string>> { }
}
