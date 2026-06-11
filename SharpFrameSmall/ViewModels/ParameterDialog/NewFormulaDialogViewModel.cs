using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SharpFrameSmall.ViewModels
{
    public class NewFormulaDialogViewModel : BindableBase, IDialogAware
    {
        public NewFormulaDialogViewModel(IEventAggregator aggregator)
        {
            // aggregator.GetEvent<MainLogOutput>().Publish(new MainLogStructure() { Time = DateTime.Now.ToString(), Level = "正常", Value = "程序加载完成" });
            ConfirmNew = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(NewNameValue))
                {
                    if (!Names.Contains(NewNameValue))
                    {
                        OnDialogClosed();
                    }
                    else
                    {
                        MessageBox.Show(
                            "The name already exists, please choose another name.",
                            "Error",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "The name cannot be empty.",
                        "Error",
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Error);
                }
            });
        }

        /// <summary>
        /// 当前参数名称
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// 型号切换DropDownClosed命令
        /// </summary>
        public DelegateCommand ModelSwitching { get; set; }

        private int _parameterindexes = 0;
        /// <summary>
        /// 参数型号选择ComboBox
        /// </summary>
        public int ParameterIndexes
        {
            get { return _parameterindexes; }
            set { SetProperty(ref _parameterindexes, value); }
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

        public List<string> Names { get; set; }

        private string _title = "Added recipe";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _newnamevalue;

        public string NewNameValue
        {
            get { return _newnamevalue; }
            set { SetProperty(ref _newnamevalue, value); }
        }

        public DelegateCommand ConfirmNew { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            IDialogParameters parameters = new DialogParameters();
            parameters.Add("NewName", NewNameValue);
            parameters.Add("CopyName", ParameterName);
            RequestClose?.Invoke(new Prism.Services.Dialogs.DialogResult(ButtonResult.OK, parameters));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Names = parameters.GetValue<List<string>>("Names");
            for (int i = 0; i < Names.Count; i++)
                ParameterNameList.Add(new ComboxList { ID = i, Name = Names[i] });
            ParameterName = Names[0];
        }
    }
}
