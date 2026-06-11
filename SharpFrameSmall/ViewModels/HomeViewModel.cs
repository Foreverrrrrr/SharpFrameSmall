using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SharpFrameSmall.log4Net;
using SharpFrameSmall.Logic.AutoMain;
using SharpFrameSmall.Logic.Base;
using SharpFrameSmall.Structure.Parameter;
using SharpFrameSmall.ViewModels.Structure;
using SharpFrameSmall.Views.SharpStyle;
using System;
using System.Linq;
using static SharpFrameSmall.Logic.Base.ProcessBase;

namespace SharpFrameSmall.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;

        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private UserLevel _currentuserlevel;

        public UserLevel CurrentUserLevel
        {
            get { return _currentuserlevel; }
            set { _currentuserlevel = value; RaisePropertyChanged(); }
        }

        private ParameterEditMode _systemEditMode;

        public ParameterEditMode SystemEditMode
        {
            get { return _systemEditMode; }
            set { _systemEditMode = value; RaisePropertyChanged(); }
        }

        private ParameterStore _store;

        public ParameterStore Store
        {
            get { return _store; }
            set { _store = value; }
        }

        public HomeViewModel(IEventAggregator aggregator, IRegionManager regionManager, IDialogService dialog)
        {
            this.regionManager = regionManager;
            this.eventAggregator = aggregator;
            this.dialogService = dialog;
            eventAggregator.GetEvent<LoginPermission>().Subscribe((type) =>
            {
                CurrentUserLevel = type.Level;
                if (type.Level < UserLevel.Admin)
                    SystemEditMode = ParameterEditMode.ReadOnly;
                else
                    SystemEditMode = ParameterEditMode.Full;
            });
            eventAggregator.GetEvent<ParameterUpdateEvent>().Subscribe((x) =>
            {
                Store = x;
            });
            eventAggregator.GetEvent<PageLoadEvent>().Subscribe((classobj) =>
            {
                try
                {
                    ProcessBase.NewClass_RunEvent += (time, name, instance) =>
                    {
                        if (instance is Logic.AutoMain.Auto auto)
                        {
                            auto.LogEvent += (t, msg) =>
                            {
                                Log.Info(msg);
                                eventAggregator.GetEvent<AutoLogOutput>().Publish(msg);
                            };
                        }
                    };
                    ProcessBase.NewClass(new object[] { aggregator, Store });
                    Exchange.External_IO(Send_Variable.Reset);
                    ProcessBase.InitializeStart();
                   // Exchange.External_IO(Send_Variable.Start);
                }
                catch (Exception ex)
                {
                    Log.Error($"PageLoadEvent callback failed: {ex}"); 
                }
            }, ThreadOption.UIThread, keepSubscriberReferenceAlive:true);
            aggregator.GetEvent<LanguageSwitch>().Subscribe((s) =>
            {

            }, ThreadOption.UIThread);
        }

        ~HomeViewModel()
        {

        }
    }
}
