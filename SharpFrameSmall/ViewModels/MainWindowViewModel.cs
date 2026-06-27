using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common;
using SharpFrameSmall.language;
using SharpFrameSmall.log4Net;
using SharpFrameSmall.Logic.Base;
using SharpFrameSmall.Structure.Parameter;
using SharpFrameSmall.Update;
using SharpFrameSmall.ViewModels.Structure;
using SharpFrameSmall.Views;
using SharpFrameSmall.Views.SharpStyle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using static SharpFrameSmall.Logic.Base.ProcessBase;

namespace SharpFrameSmall.ViewModels
{
    public delegate bool LogicStates();

    public class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;
        public LogicStates ButtonLogic { get; set; }
        private string activeuser;

        public string ActiveUser
        {
            get { return activeuser; }
            set { activeuser = value; RaisePropertyChanged(); }
        }

        public User AtUser { get; set; }
        /// <summary>
        /// 页面导航Command
        /// </summary>
        public DelegateCommand<string> VisionSwitching { get; set; }

        /// <summary>
        /// 软件关闭前Command
        /// </summary>
        public DelegateCommand Close { get; set; }

        /// <summary>
        /// 页面初始化加载完成Command
        /// </summary>
        public DelegateCommand PageLoadFinish { get; set; }

        /// <summary>
        /// 登入权限Command
        /// </summary>
        public static DelegateCommand PermissionCommand { get; set; }

        private string _versiontextblock;
        /// <summary>
        /// 版本号
        /// </summary>
        public string VersionTextBlock
        {
            get { return _versiontextblock; }
            set
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                value = $"Version:{version.Major}.{version.Minor}.{version.Revision}";
                //Update.VersionInfo info = new Update.VersionInfo();
                //info.Version = $"{version.Major}.{version.Minor}.{version.Revision}";
                //string serializedResult = JToken.Parse(JsonConvert.SerializeObject(info)).ToString();
                //string outputPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
                //System.IO.File.WriteAllText(outputPath, serializedResult);
                SetProperty(ref _versiontextblock, value);
            }
        }
       
        private readonly LocalizationService _localizationService = new LocalizationService();
        private List<LanguageItem> languages = new List<LanguageItem>()
        {
            new LanguageItem { Display = "中文简体", Culture = "zh-CN" },
            new LanguageItem { Display = "中文繁体", Culture = "zh-TW" },
            new LanguageItem { Display = "English",  Culture = "en-US" },
            new LanguageItem { Display = "Tiếng Việt", Culture = "vi-VN"  }
        };

        public List<LanguageItem> Languages
        {
            get { return languages; }
            set { languages = value; RaisePropertyChanged(); }
        }

        private LanguageItem _selectedLanguage;
        public LanguageItem SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (SetProperty(ref _selectedLanguage, value) && value != null)
                    _localizationService.ChangeCulture(value.Culture);
            }
        }

        public MainWindowViewModel(IEventAggregator aggregator, IRegionManager regionManager, IDialogService dialog)
        {
            this.regionManager = regionManager;
            this.eventAggregator = aggregator;
            this.dialogService = dialog;
            eventAggregator.GetEvent<PageLoadEvent>().Subscribe((classobj) =>
            {
                VersionTextBlock = string.Empty;
                Stop_State = true;
                aggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure() { Time = DateTime.Now.ToString(), Level = "正常", Value = "程序加载完成" });
                var saved = _localizationService.LoadSavedCulture();
                SelectedLanguage = Languages.FirstOrDefault(l => l.Culture == saved) ?? Languages[0];
                CheckUpdate.Log += ((s) =>
                {
                    eventAggregator.GetEvent<AutoLogOutput>().Publish(s);
                });
                StartUpdateChecker();
            });
            eventAggregator.GetEvent<Notification>().Subscribe((t) =>
            {
                NotificationModel model = null;
                switch (t.Type)
                {
                    case Notification.InfoType.Info:
                        model = new NotificationInfoModel() { ID = IsNotice.Count, Message = t.Message, MessageTime = t.MessageTime };
                        break;
                    case Notification.InfoType.Warning:
                        model = new NotificationWarningModel() { ID = IsNotice.Count, Message = t.Message, MessageTime = t.MessageTime };
                        break;
                    case Notification.InfoType.Error:
                        model = new NotificationErrorModel()
                        {
                            ID = IsNotice.Count,
                            Message = t.Message,
                            MessageTime = t.MessageTime,
                        };
                        model.Delete = new DelegateCommand<object>((obj) =>
                        {
                            var rmove = IsNotice.Where(x => x.ID == Convert.ToInt32(obj)).First();
                            IsNotice.Remove(rmove);
                        });
                        break;
                    case Notification.InfoType.Fatal:
                        model = new NotificationFatalModel() { ID = IsNotice.Count, Message = t.Message, MessageTime = t.MessageTime };
                        break;
                }
                IsNotice.Insert(IsNotice.Count, model);
            }, ThreadOption.UIThread);
            IsNotice.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems)
                    {
                        if (item is NotificationModel timedItem)
                        {
                            timedItem.AutoRemoveRequested += (sender, args) =>
                                Application.Current.Dispatcher.Invoke(() => IsNotice.Remove((NotificationModel)item));
                        }
                    }
                }
            };
            VisionSwitching = new DelegateCommand<string>((ManagerName) =>
            {
                try
                {
                    regionManager.Regions["MainRegion"].RequestNavigate(ManagerName);
                }
                catch (Exception ex)
                {

                }
            });
            Close = new DelegateCommand(() =>
            {
                // 先启动更新检测进程（Update.exe 会等待主程序退出后再执行更新）
                string updateServerUrl = Properties.Settings.Default.UpdateServerUrl;
                CheckUpdate check = new CheckUpdate(updateServerUrl);

                try
                {
                    Thread_Dispose();
                    eventAggregator
                        .GetEvent<Close_MessageEvent>()
                        .Publish();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Application.Current.Shutdown();
                    Environment.Exit(0);
                }
            });
            PermissionCommand = new DelegateCommand(() =>
            {
                IDialogParameters dialogParameters = new DialogParameters();
                dialogParameters.Add("At", AtUser);
                dialog.ShowDialog("SystemLogInView", dialogParameters, (result) =>
                {
                    if (result.Result == ButtonResult.OK)
                    {
                        AtUser = result.Parameters.GetValue<User>("At");
                        ActiveUser = AtUser.Name;
                        eventAggregator.GetEvent<LoginPermission>().Publish(AtUser);
                        //string copyData = result.Parameters.GetValue<string>("CopyName");
                        eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                        {
                            Time = DateTime.Now.ToString(),
                            Level = "正常",
                            Value = $"登入 {ActiveUser} 权限"
                        });
                    }
                });
            });
            eventAggregator.GetEvent<Loadingbar>().Subscribe((t) =>
            {
                if (t)
                    LoadingBarState = true;
                else
                    LoadingBarState = false;
            });
            PageLoadFinish = new DelegateCommand(async () =>
            {
                aggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure() { Time = DateTime.Now.ToString(), Level = "正常", Value = "正在初始化......" });
                LoadingBarState = true;
                var userlist = UserManagement.GetAllUser();
                AtUser = userlist.Find(x => x.Name == "Operator");
                UserManagement.LoginUser(AtUser);
                ActiveUser = AtUser.Name;
                aggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                {
                    Time = DateTime.Now.ToString(),
                    Level = "正常",
                    Value = $"登入 {ActiveUser} 权限"
                });
                eventAggregator.GetEvent<LoginPermission>().Publish(AtUser);
                List<object> pageLoadparameter = new List<object>();
                await Task.Run(() =>
                {
                    var system_list = ParameterJsonTool.GetRecipeNames();
                    pageLoadparameter.Add(system_list);
                    InfoStructure info = new InfoStructure();
                    ProductionInformation.ReadProductionInfo(ref info);
                    ProductionInformation.StartShiftWatcher(DateTime.Today.AddHours(8), DateTime.Today.AddHours(20));
                    pageLoadparameter.Add(info);
                });
                eventAggregator.GetEvent<PageLoadEvent>().Publish(pageLoadparameter.ToArray());
                LoadingBarState = false;
            });
            Viewinitial();
        }

        private Update.UpdateListener _updateListener;
        private void StartUpdateChecker()
        {
            try
            {
                string serverUrl = SharpFrameSmall.Properties.Settings.Default.UpdateServerUrl;
                // TCP 端口 = HTTP 端口 + 1（如 http://x.x.x.x:12222 → TCP 12223）
                _updateListener = new Update.UpdateListener(serverUrl);
                _updateListener.Start();
            }
            catch
            {
                // 更新检测不是关键功能，启动失败不阻止程序运行
            }
        }

        /// <summary>
        /// 页面初始化加载
        /// </summary>
        private void Viewinitial()
        {
            regionManager.RegisterViewWithRegion("ToolRegion", typeof(LogControl));
            regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeView));
            regionManager.RegisterViewWithRegion("MainRegion", typeof(ParameterView));
            regionManager.RegisterViewWithRegion("MainRegion", typeof(DataBaseView));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(DebuggingView));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(RelationalDatabaseView));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(LogView));
        }

        #region 启动按钮
        private bool _start_state = false;
        /// <summary>
        /// 启动按钮状态
        /// </summary>
        public bool Start_State
        {
            get { return _start_state; }
            set
            {
                if (!_start_state && value && Exchange.External_IO(Send_Variable.Start))
                {

                    Log.Info("启动按钮触发");
                    eventAggregator.GetEvent<StartInform>().Publish();
                    _start_state = value;
                    RaisePropertyChanged();
                    SystemState = "自动运行";
                }
                else if (!value)
                {
                    _start_state = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 暂停按钮
        private bool _suspend_state = false;
        /// <summary>
        /// 暂停按钮状态
        /// </summary>
        public bool Suspend_State
        {
            get { return _suspend_state; }
            set
            {
                if (!_suspend_state && value && Exchange.External_IO(Send_Variable.Suspend))
                {
                    Log.Info("暂停按钮触发");
                    eventAggregator.GetEvent<SuspendInform>().Publish();
                    _suspend_state = value;
                    RaisePropertyChanged();
                    SystemState = "暂停";
                }
                else if (!value)
                {
                    _suspend_state = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 停止按钮
        private bool _stop_state;
        /// <summary>
        /// 停止按钮状态
        /// </summary>
        public bool Stop_State
        {
            get { return _stop_state; }
            set
            {
                if (!_stop_state && value && Exchange.External_IO(Send_Variable.Stop))
                {
                    Log.Info("停止按钮触发");
                    eventAggregator.GetEvent<StopInform>().Publish();
                    _stop_state = value;
                    RaisePropertyChanged();
                    SystemState = "停止";
                }
                else if (!value)
                {
                    _stop_state = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 复位按钮
        private bool _reset_state = false;
        /// <summary>
        /// 复位按钮状态
        /// </summary>
        public bool Reset_State
        {
            get { return _reset_state; }
            set
            {
                if (!_reset_state && value && Exchange.External_IO(Send_Variable.Reset))
                {
                    SystemState = "复位中";
                    Log.Info("复位按钮触发");
                    LoadingBarState = true;
                    eventAggregator.GetEvent<ResetInform>().Publish();
                    LoadingBarState = false;
                    _reset_state = value;
                    RaisePropertyChanged();
                }
                else if (!value)
                {
                    _reset_state = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 紧急停止按钮
        private bool _urgencystop_state;
        /// <summary>
        /// 紧急停止按钮状态
        /// </summary>
        public bool UrgencyStop_State
        {
            get { return _urgencystop_state; }
            set { _urgencystop_state = value; }
        }
        #endregion

        private string _title = "Prism Application";
        /// <summary>
        /// 应用程序抬头
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _loadingbarstate = false;
        /// <summary>
        /// 滑动加载条状态
        /// </summary>
        public bool LoadingBarState
        {
            get { return _loadingbarstate; }
            set { SetProperty(ref _loadingbarstate, value); }
        }

        private string _system_state;

        public string SystemState
        {
            get { return _system_state; }
            set { SetProperty(ref _system_state, value); }
        }

        private ObservableCollection<NotificationModel> _isNotice = new ObservableCollection<NotificationModel>();
        /// <summary>
        /// 悬浮弹窗集合
        /// </summary>
        public ObservableCollection<NotificationModel> IsNotice
        {
            get { return _isNotice; }
            set { SetProperty(ref _isNotice, value); }
        }

        #region 获取显示器分辨率
        private double _height = SystemParameters.PrimaryScreenHeight - 300;
        public double Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }

        private double _width = SystemParameters.PrimaryScreenWidth - 250;

        public double Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }
        #endregion
    }

    /// <summary>
    /// 页面初始化完成通知 object[]初始化对象
    /// </summary>
    public class PageLoadEvent : PubSubEvent<object[]> { }
    /// <summary>
    /// 应用程序关闭通知
    /// </summary>
    public class Close_MessageEvent : PubSubEvent { }
    /// <summary>
    /// 登入权限通知
    /// </summary>
    public class LoginPermission : PubSubEvent<User> { }
    /// <summary>
    /// 启动通知
    /// </summary>
    public class StartInform : PubSubEvent { }
    /// <summary>
    /// 暂停通知
    /// </summary>
    public class SuspendInform : PubSubEvent { }
    /// <summary>
    /// 停止通知
    /// </summary>
    public class StopInform : PubSubEvent { }
    /// <summary>
    /// 复位通知
    /// </summary>
    public class ResetInform : PubSubEvent { }
    /// <summary>
    /// 进度条动画通知
    /// </summary>
    public class Loadingbar : PubSubEvent<bool> { }
    /// <summary>
    /// 多语言切换
    /// </summary>
    public class LanguageSwitch : PubSubEvent<string> { }
}
