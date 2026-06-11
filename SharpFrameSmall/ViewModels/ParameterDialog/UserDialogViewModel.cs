using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SharpFrameSmall.Common;
using SharpFrameSmall.ViewModels.Structure;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SharpFrameSmall.ViewModels
{
    public class UserDialogViewModel : BindableBase, IDialogAware
    {

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }

        private string _edituser;

        public string EditUser
        {
            get { return _edituser; }
            set { _edituser = value; RaisePropertyChanged(); }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; RaisePropertyChanged(); }
        }

        private string _title = "User Management";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private UserLevel _currentuserlevel;
        /// <summary>
        /// 当前权限
        /// </summary>
        public UserLevel CurrentUserLevel
        {
            get { return _currentuserlevel; }
            set { _currentuserlevel = value; RaisePropertyChanged(); }
        }

        public event Action<IDialogResult> RequestClose;

        public UserDialogViewModel(IEventAggregator aggregator)
        {
            AddCommand = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(EditUser))
                {
                    if (Users.Any(x => x.Name == Username))
                    {
                        MessageBox.Show("Cannot be increased. This user already exists.",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        if(UserManagement.CreateUser(Username, EditUser))
                        {
                            RefreshCommand.Execute();
                            MessageBox.Show("User creation successful.",
                           "Information",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("User creation failed.",
                           "Error",
                           MessageBoxButton.OK,
                           MessageBoxImage.Error);
                        }
                    }
                }
            });
            UpdateCommand = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(EditUser))
                {
                    if (!Users.Any(x => x.Name == Username))
                    {
                        MessageBox.Show("Cannot be increased. This user already exists.",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                       if( UserManagement.ModifyUserInformation(Username, null, EditUser))
                        {
                            RefreshCommand.Execute();
                            MessageBox.Show("Password modification successful.",
                            "Information",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                            return;
                        }
                       else
                        {
                            MessageBox.Show("Failed to modify password.",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        }
                    }
                }
            });
            DeleteCommand = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(Username))
                {
                    if (!Users.Any(x => x.Name == Username))
                    {
                        MessageBox.Show("The user does not exist.",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (UserManagement.DeleteUser(Username))
                            {
                                RefreshCommand.Execute();
                                MessageBox.Show("User deletion successful.",
                               "Information",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete user.",
                               "Error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,
                              "Error",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
                        }
                        
                    }
                }
            });
            RefreshCommand = new DelegateCommand(() =>
            {
                var t = UserManagement.GetAllUser();
                Users = new ObservableCollection<User>(t);
            });
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var t = UserManagement.GetAllUser();
            Users = new ObservableCollection<User>(t);
        }
    }
}
