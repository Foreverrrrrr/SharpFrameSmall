using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace SharpFrameSmall.Common
{
    /// <summary>
    /// Excel 对话框数据操作接口 — 将泛型操作封装为非泛型接口，
    /// 使得单个 ViewModel 可以处理任意数据类型
    /// </summary>
    public interface IExcelDialogHelper
    {
        /// <summary>
        /// 从 Excel 读取数据
        /// </summary>
        void LoadData(string path, string table);

        /// <summary>
        /// 获取用于 DataGrid 绑定的可编辑集合
        /// </summary>
        IEnumerable GetDisplayCollection();

        /// <summary>
        /// 获取变更数量
        /// </summary>
        int GetChangedCount();

        /// <summary>
        /// 获取变更描述信息列表
        /// </summary>
        List<string> GetChangeDescriptions();

        /// <summary>
        /// 将变更写回 Excel
        /// </summary>
        bool ApplyUpdates(string path, string table);
    }

    /// <summary>
    /// Excel 对话框泛型数据操作实现
    /// </summary>
    public class ExcelDialogHelper<T> : IExcelDialogHelper where T : class, new()
    {
        private List<T> _original = new List<T>();
        private ObservableCollection<T> _display = new ObservableCollection<T>();

        public void LoadData(string path, string table)
        {
            _original = new List<T>();
            ExcelTool.ReadExcelData<T>(path, table, ref _original);

            _display = new ObservableCollection<T>();
            foreach (var item in _original)
                _display.Add(ExcelTool.CopyItem(item));
        }

        public IEnumerable GetDisplayCollection() => _display;

        public int GetChangedCount()
        {
            int count = 0;
            int len = Math.Min(_original.Count, _display.Count);
            for (int i = 0; i < len; i++)
            {
                if (!ExcelTool.CompareItems(_original[i], _display[i]))
                    count++;
            }
            return count;
        }

        public List<string> GetChangeDescriptions()
        {
            var descriptions = new List<string>();
            int len = Math.Min(_original.Count, _display.Count);
            for (int i = 0; i < len; i++)
            {
                if (!ExcelTool.CompareItems(_original[i], _display[i]))
                {
                    var diffs = ExcelTool.GetItemDiffs(_original[i], _display[i]);
                    string diffDetail = string.Join(", ", diffs);
                    descriptions.Add($"第 {i + 2} 行變更: {diffDetail}");
                }
            }
            return descriptions;
        }

        public bool ApplyUpdates(string path, string table)
        {
            Dictionary<int, T> pairs = new Dictionary<int, T>();
            int len = Math.Min(_original.Count, _display.Count);
            for (int i = 0; i < len; i++)
            {
                if (!ExcelTool.CompareItems(_original[i], _display[i]))
                    pairs.Add(i + 2, _display[i]);
            }
            if (pairs.Count > 0)
                return ExcelTool.UpdateExcelData<T>(path, table, pairs);
            return true;
        }
    }

    /// <summary>
    /// ExcelDialogHelper 工厂 — 根据 Type 创建对应的泛型实例
    /// </summary>
    public static class ExcelDialogHelperFactory
    {
        public static IExcelDialogHelper Create(Type dataType)
        {
            var helperType = typeof(ExcelDialogHelper<>).MakeGenericType(dataType);
            return (IExcelDialogHelper)Activator.CreateInstance(helperType);
        }
    }
}
