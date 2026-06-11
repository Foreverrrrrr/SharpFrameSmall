using Prism.Events;
using Prism.Mvvm;
using SharpFrameSmall.log4Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SharpFrameSmall.ViewModels
{
    public class LogControlViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly LinkedList<string> _logBuffer = new LinkedList<string>();
        private readonly StringBuilder _sb = new StringBuilder(8192);
        private const int MaxLogLines = 100;

        private string _logText = string.Empty;
        public string LogText
        {
            get => _logText;
            set => SetProperty(ref _logText, value);
        }

        public ObservableCollection<MainLogStructure> Logs { get; } = new ObservableCollection<MainLogStructure>();

        public LogControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MainLogOutput>().Subscribe(OnLogReceived, ThreadOption.UIThread);
            _eventAggregator.GetEvent<AutoLogOutput>().Subscribe(AppendLog, ThreadOption.UIThread);
        }

        public void AppendLog(string message)
        {
            _logBuffer.AddFirst($"[{DateTime.Now:HH:mm:ss}] {message}");
            if (_logBuffer.Count > MaxLogLines)
                _logBuffer.RemoveLast();

            _sb.Clear();
            foreach (var line in _logBuffer)
                _sb.AppendLine(line);

            LogText = _sb.ToString();
        }

        private void OnLogReceived(MainLogStructure log)
        {
            Logs.Insert(0, log);
            while (Logs.Count > MaxLogLines)
                Logs.RemoveAt(Logs.Count - 1);
        }
    }
}

