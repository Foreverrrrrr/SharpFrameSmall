using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using SharpFrameSmall;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 支持批量操作的 ObservableCollection
    /// <para>提供 ReplaceRange、AddRange、Sort 等不逐条触发通知的批量方法</para>
    /// </summary>
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _suppressNotification = false;

        /// <summary>
        /// 在 UI 线程执行操作，若无 Dispatcher 则直接在当前线程执行
        /// </summary>
        private void RunOnDispatcher(Action action)
        {
            var dispatcher = App.Current?.Dispatcher;
            if (dispatcher != null)
            {
                dispatcher.Invoke(action);
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// 清空并替换为新数据（只触发一次 Reset 通知）
        /// </summary>
        public void ReplaceRange(IEnumerable<T> items)
        {
            if (items == null) return;
            RunOnDispatcher(() =>
            {
                this.Items.Clear();
                foreach (var item in items)
                {
                    base.Items.Add(item);
                }
                base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            });
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null) return;
            RunOnDispatcher(() =>
            {
                _suppressNotification = true;
                try
                {
                    foreach (var item in items)
                    {
                        base.Items.Add(item);
                    }
                }
                finally
                {
                    _suppressNotification = false;
                    base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            });
        }

        /// <summary>
        /// 按条件批量移除
        /// </summary>
        public int RemoveRange(Func<T, bool> predicate)
        {
            if (predicate == null) return 0;
            int removed = 0;
            RunOnDispatcher(() =>
            {
                _suppressNotification = true;
                try
                {
                    var toRemove = this.Items.Where(predicate).ToList();
                    foreach (var item in toRemove)
                    {
                        this.Items.Remove(item);
                        removed++;
                    }
                }
                finally
                {
                    _suppressNotification = false;
                    if (removed > 0)
                        base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            });
            return removed;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public void Sort<TKey>(Func<T, TKey> keySelector, bool ascending = true)
        {
            if (keySelector == null) return;
            RunOnDispatcher(() =>
            {
                _suppressNotification = true;
                try
                {
                    var sorted = ascending
                        ? this.Items.OrderBy(keySelector).ToList()
                        : this.Items.OrderByDescending(keySelector).ToList();
                    this.Items.Clear();
                    foreach (var item in sorted)
                    {
                        this.Items.Add(item);
                    }
                }
                finally
                {
                    _suppressNotification = false;
                    base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            });
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
                base.OnCollectionChanged(e);
        }
    }
}
