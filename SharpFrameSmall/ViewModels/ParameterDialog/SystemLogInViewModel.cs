using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common;
using SharpFrameSmall.log4Net;
using SharpFrameSmall.ViewModels.Structure;
using System;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SharpFrameSmall.ViewModels
{
    public class SystemLogInViewModel : BindableBase, IDialogAware
    {
        public User AtUser { get; set; }

        public event Action<IDialogResult> RequestClose;

        private readonly IEventAggregator eventAggregator;

        private CancellationTokenSource _cts;

        public DelegateCommand Login_button { get; set; }
        public DelegateCommand OutLogin_button { get; set; }
        public DelegateCommand Administration { get; set; }
        private string _title = "昆山可腾电子";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _password = "1234";

        /// <summary>
        /// 输入密码
        /// </summary>
        public string PassWord
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _username;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private bool _upload = true;
        /// <summary>
        /// 加载标志位
        /// </summary>
        public bool Upload
        {
            get { return _upload; }
            set
            {
                if (value)
                {
                    UploadProgressBar = false;
                }
                else
                {
                    UploadProgressBar = true;
                }
                SetProperty(ref _upload, value);
            }
        }

        private UserLevel _currentuserlevel;

        public UserLevel CurrentUserLevel
        {
            get { return _currentuserlevel; }
            set { _currentuserlevel = value; RaisePropertyChanged(); }
        }


        private bool _uploadprogressbar = false;
        public bool UploadProgressBar
        {
            get { return _uploadprogressbar; }
            set { SetProperty(ref _uploadprogressbar, value); }
        }

        private int _countdownvalue = 0;
        private bool _isLoginExecuting;

        public int CountDownValue
        {
            get { return _countdownvalue; }
            set { SetProperty(ref _countdownvalue, value); }
        }

        public SystemLogInViewModel(IEventAggregator aggregators, IDialogService dialog)
        {
            this.eventAggregator = aggregators;
            Login_button = new DelegateCommand(() =>
            {
                if (Username != AtUser.Name)
                {
                    if (ExecutePermission(Username, PassWord))
                    {
                        OnDialogClosed();
                    }
                }
                else
                {
                    eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                    {
                        Time = DateTime.Now.ToString(),
                        Level = "正常",
                        Value = $"重复登入"
                    });
                }
            });
            OutLogin_button = new DelegateCommand(() =>
            {
                var userlist = UserManagement.GetAllUser();
                AtUser = userlist.Find(x => x.Name == "Operator");
                UserManagement.LoginUser(AtUser);
                PassWord = AtUser.PassWord;
                Username = AtUser.Name;
                OnDialogClosed();
            });
            Administration = new DelegateCommand(() =>
            {
                IDialogParameters dialogParameters = new DialogParameters();
                dialog.ShowDialog("UserDialog", dialogParameters, (result) =>
                {
                    if (result.Result == ButtonResult.OK)
                    {

                    }
                });
            });
        }

        private bool ExecutePermission(string permissionType, string password)
        {
            var t = UserManagement.LoginUser(permissionType, password);
            if (t == null && permissionType != null)
            {
                eventAggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure()
                {
                    Time = DateTime.Now.ToString(),
                    Level = "正常",
                    Value = $"输入密码错误"
                });
                MessageBox.Show("Incorrect password entered.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

                return false;
            }
            else
            {
                AtUser = new User() { Name = t.Name, PassWord = t.PassWord, Level = t.Level };
            }
            return true;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("At", AtUser);
            RequestClose?.Invoke(new Prism.Services.Dialogs.DialogResult(ButtonResult.OK, parameters));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            AtUser = parameters.GetValue<User>("At");
            PassWord = AtUser.PassWord;
            Username = AtUser.Name;
            CurrentUserLevel = AtUser.Level;
        }
    }
}
