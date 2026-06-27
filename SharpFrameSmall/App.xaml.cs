using Prism.Ioc;
using SharpFrameSmall.Common;
using SharpFrameSmall.Common.Commumication;
using SharpFrameSmall.ViewModels;
using SharpFrameSmall.Views;
using SharpFrameSmall.Views.ParameterDialog;
using System.Diagnostics;
using System.Windows;

namespace SharpFrameSmall
{
    //Copyright © 2024 Mr. Xu YiFan
    // 1. This software is intended for demonstration and educational purposes only and must not be used for commercial purposes.
    // 2. Modification, reproduction, or redistribution of this software without authorization from Mr.Xu YiFan is prohibited.
    // 3. Mr.Xu YiFan shall not be liable for any loss or damage resulting from the use of this software.
    // 4. In case of encountering bugs or providing suggestions for improvement, please contact Mr.Xu YiFan at awalkingonthecloud@gmail.com.
    public partial class App
    {
        public App()
        {
            if (HaveRunningInstance())
            {
                System.Windows.MessageBox.Show($"请勿重复打开应用程序", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                Process.GetCurrentProcess().Kill();
            }
        }

        protected override void OnInitialized()
        {
            ProductionInformation.SetDataDB();
            UserManagement.SetUseDB();
            base.OnInitialized();
        }



        /// <summary>
        /// 判断是否已经存在运行的实例
        /// </summary>
        /// <returns>存在返回true，不存在返回false</returns>
        public static bool HaveRunningInstance()
        {
            System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(current.ProcessName);
            if (processes.Length >= 2)
                return true;
            else
                return false;
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<AsyncSharpTcpClient>();
            containerRegistry.RegisterSingleton<AsyncSharpTcpServer>();
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<ParameterView>();
            containerRegistry.RegisterForNavigation<LogControl>();
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<DataBaseView>();
            containerRegistry.RegisterForNavigation<MotionDebugView>();
            containerRegistry.RegisterForNavigation<NewFormulaDialog, NewFormulaDialogViewModel>();
            containerRegistry.RegisterForNavigation<ErrorCodeDialog, ErrorCodeDialogViewModel>();
            containerRegistry.RegisterForNavigation<SystemLogInView, SystemLogInViewModel>();
            containerRegistry.RegisterForNavigation<UserDialog, UserDialogViewModel>(); 
        }
    }
}
