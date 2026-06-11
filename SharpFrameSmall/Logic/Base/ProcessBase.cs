using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SharpFrameSmall.Logic.Base
{
    public abstract class ProcessBase
    {
        /// <summary>
        /// 流程线程创建事件
        /// </summary>
        public static event Action<DateTime, string, object> NewClass_RunEvent;

        /// <summary>
        /// 全局状态机日志事件
        /// </summary>
        public static event Action<DateTime, string> DataConfigurationEvent;

        private static readonly object _lock = new object();
        private static readonly object _autoThLock = new object();

        /// <summary>
        /// 全局状态机枚举快速查找表
        /// </summary>
        private static readonly Dictionary<string, int> DataEnumLookup = new Dictionary<string, int>();

        /// <summary>
        /// 全局状态机数据池
        /// </summary>
        private static readonly bool[] DataPool = new bool[65535];

        private static readonly List<ProductionThreadInfo> _autoTh = new List<ProductionThreadInfo>();

        /// <summary>
        /// 共享参数字典
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> _sharedObjects = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// 注册/更新单个共享参数
        /// </summary>
        public static void SetShared<T>(T obj) where T : class
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            Type type = obj.GetType();
            _sharedObjects[type] = obj;
            foreach (var iface in type.GetInterfaces())
                _sharedObjects[iface] = obj;
            Type baseType = type.BaseType;
            while (baseType != null && baseType != typeof(object))
            {
                _sharedObjects[baseType] = obj;
                baseType = baseType.BaseType;
            }
            DataConfigurationEvent?.Invoke(DateTime.Now, $"共享参数已更新: {typeof(T).Name}");
        }

        /// <summary>
        /// 获取指定类型的共享参数
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>匹配类型的对象，未找到返回 default</returns>
        public static T GetShared<T>() where T : class
        {
            if (_sharedObjects.TryGetValue(typeof(T), out var obj))
                return obj as T;
            return default;
        }

        /// <summary>
        /// 移除指定类型的共享参数
        /// </summary>
        public static bool RemoveShared<T>() where T : class
        {
            return _sharedObjects.TryRemove(typeof(T), out _);
        }

        /// <summary>
        /// 批量注册共享参数
        /// </summary>
        public static void SetSharedObjects(params object[] objects)
        {
            if (objects == null) return;
            foreach (var obj in objects)
            {
                if (obj == null) continue;
                Type type = obj.GetType();
                _sharedObjects[type] = obj;
                foreach (var iface in type.GetInterfaces())
                    _sharedObjects[iface] = obj;
                Type baseType = type.BaseType;
                while (baseType != null && baseType != typeof(object))
                {
                    _sharedObjects[baseType] = obj;
                    baseType = baseType.BaseType;
                }
            }
        }

        /// <summary>
        /// 流程线程列表
        /// </summary>
        public static IReadOnlyList<ProductionThreadInfo> Auto_Th
        {
            get { lock (_autoThLock) { return _autoTh.ToList().AsReadOnly(); } }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public abstract ManualResetEvent Interrupt { get; set; }

        /// <summary>
        /// 当前线程取消令牌
        /// </summary>
        public CancellationToken ThreadToken { get; set; }

        /// <summary>
        /// 日志接口
        /// </summary>
        public abstract event Action<DateTime, string> LogEvent;

        public enum Send_Variable
        {
            Start, AwaitStarted, Suspend, Stop, Reset, ResetOver, E_Stop
        }

        public ProcessBase() { }

        /// <summary>
        /// 流程初始化
        /// </summary>
        /// <param name="objects">自定义对象</param>
        /// <param name="spintime">线程循环休眠时间</param>
        public static void NewClass(object[] objects, int spintime = 50)
        {
            SetSharedObjects(objects);
            DataStructureConfiguration(typeof(Send_Variable));
            Type baseType = typeof(ProcessBase);
            Assembly assembly = Assembly.GetEntryAssembly();
            Type[] derivedTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType)).ToArray();
            foreach (Type derivedType in derivedTypes)
            {
                object instance = Activator.CreateInstance(derivedType);
                AutoDataStructureConfiguration(derivedType);
                (instance as ProcessBase)?.OnGetShared();
                MethodInfo[] methods = derivedType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (MethodInfo method in methods)
                {
                    var t = method.GetCustomAttributes(typeof(ProductionThreadAttribute), inherit: true);
                    if (t.Length > 0)
                        Thread_Configuration(derivedType.Name, method, instance, spintime);
                }
                NewClass_RunEvent?.Invoke(DateTime.Now, derivedType.FullName + "中自动运行线程启动", instance);
            }
        }

        /// <summary>
        /// 共享参数方法回调
        /// </summary>
        public static void GetShared()
        {
            List<ProductionThreadInfo> snapshot;
            lock (_autoThLock) { snapshot = _autoTh.ToList(); }
            foreach (var item in snapshot)
            {
                item.Class?.OnGetShared();
            }
        }

        /// <summary>
        /// 初始化方法回调
        /// </summary>
        public static void InitializeStart()
        {
            List<ProductionThreadInfo> snapshot;
            lock (_autoThLock) { snapshot = _autoTh.ToList(); }
            foreach (var item in snapshot)
            {
                item.Class?.Initialize(item.Class);
            }
        }

        public static void InitializeStart(string classname)
        {
            ProductionThreadInfo t;
            lock (_autoThLock) { t = _autoTh.Find(x => x.Thread_Name == classname); }
            if (t?.Class != null)
                t.Class.Initialize(t.Class);
        }

        private static void Thread_Configuration(string class_na, MethodInfo method, object class_new, int spintime)
        {
            ProcessBase instance = class_new as ProcessBase ?? throw new Exception("Automatic thread conversion exception");
            if (instance.Interrupt == null || IsDisposed(instance.Interrupt))
                instance.Interrupt = new ManualResetEvent(true);
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute));
            var cts = new CancellationTokenSource();
            ProductionThreadInfo threadInfo = new ProductionThreadInfo()
            {
                Target = method.Name,
                Thread_Name = descriptionAttribute?.Description ?? method.Name,
                Is_Running = true,
                CancellationSource = cts,
            };

            threadInfo.New_Thread = new Thread(() =>
            {
                instance.ThreadToken = cts.Token;
                while (!cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        instance.Interrupt?.WaitOne();
                        if (cts.Token.IsCancellationRequested) break;
                        Thread.Sleep(spintime);
                        method.Invoke(instance, new ProcessBase[] { instance });
                    }
                    catch (ThreadAbortException ex)
                    {
                        lock (_autoThLock) { _autoTh.Remove(threadInfo); }
                        Thread.ResetAbort();
                        instance.ThreadRestartEvent(class_na, instance, ex);
                        Thread_Configuration(class_na, method, class_new, spintime);
                        return;
                    }
                    catch (TargetInvocationException ex)
                    {
                        lock (_autoThLock) { _autoTh.Remove(threadInfo); }
                        if (cts.Token.IsCancellationRequested) return;
                        if (ex.InnerException is OperationCanceledException) return;
                        if (ex.InnerException is ThreadAbortException abortEx)
                        {
                            Thread.ResetAbort();
                            instance.ThreadRestartEvent(class_na, instance, abortEx);
                            Thread_Configuration(class_na, method, class_new, spintime);
                            return;
                        }
                        instance.ThreadError(class_na, instance, ex.InnerException);
                        Thread_Configuration(class_na, method, class_new, spintime);
                        return;
                    }
                }
            });
            threadInfo.New_Thread.Name = class_na + "." + threadInfo.Thread_Name;
            threadInfo.New_Thread.IsBackground = true;
            threadInfo.New_Thread.Start();
            threadInfo.Class = instance;
            threadInfo.Interrupt = instance.Interrupt;
            lock (_autoThLock) { _autoTh.Add(threadInfo); }
        }

        /// <summary>
        /// 线程中断暂停
        /// </summary>
        public static void Thread_Stop()
        {
            lock (_autoThLock)
            {
                foreach (var item in _autoTh)
                {
                    item.Interrupt?.Reset();
                }
            }
        }

        /// <summary>
        /// 线程中断复位
        /// </summary>
        public static void Thread_Reset()
        {
            lock (_autoThLock)
            {
                foreach (var item in _autoTh)
                {
                    item.Interrupt?.Set();
                }
            }
        }

        /// <summary>
        /// 全部流程线程销毁
        /// </summary>
        public static void Thread_Dispose()
        {
            List<ProductionThreadInfo> snapshot;
            lock (_autoThLock)
            {
                snapshot = _autoTh.ToList();
                _autoTh.Clear();
            }
            foreach (var item in snapshot)
            {
                DisposeThread(item);
            }
        }

        /// <summary>
        /// 指定流程线程销毁
        /// </summary>
        /// <param name="threadName">线程名称</param>
        public static void Thread_Dispose(string threadName)
        {
            ProductionThreadInfo target;
            lock (_autoThLock)
            {
                target = _autoTh.FirstOrDefault(x => x.Thread_Name == threadName);
                if (target != null) _autoTh.Remove(target);
            }
            if (target != null)
            {
                DisposeThread(target);
            }
        }

        private static bool IsDisposed(ManualResetEvent mre)
        {
            try
            {
                var _ = mre.SafeWaitHandle;
                return mre.SafeWaitHandle.IsClosed || mre.SafeWaitHandle.IsInvalid;
            }
            catch (ObjectDisposedException)
            {
                return true;
            }
        }

        /// <summary>
        /// 销毁单个线程
        /// </summary>
        private static void DisposeThread(ProductionThreadInfo item)
        {
            item.Is_Running = false;
            item.CancellationSource?.Cancel();
            item.Interrupt?.Set();
            if (item.New_Thread?.IsAlive == true && !item.New_Thread.Join(500))
            {
                try { item.New_Thread.Abort(); } catch { }
                item.New_Thread.Join(3000);
            }
            item.CancellationSource?.Dispose();
        }

        private static void AutoDataStructureConfiguration(Type derivedType)
        {
            Type[] nestedEnums = derivedType.GetNestedTypes()
                .Where(t => t.IsEnum)
                .ToArray();
            foreach (Type enumType in nestedEnums)
            {
                DataStructureConfiguration(enumType);
            }
        }

        /// <summary>
        /// 信号机枚举配置
        /// </summary>
        /// <param name="enum">枚举类型</param>
        /// <exception cref="Exception"></exception>
        protected static void DataStructureConfiguration(Type @enum)
        {
            if (!@enum.IsEnum)
                throw new ArgumentException("@enum不是枚举类型，请检查@enum的类型", nameof(@enum));

            string enumname = @enum.FullName;
            FieldInfo[] fields = @enum.GetFields(BindingFlags.Public | BindingFlags.Static);
            if (fields.Length == 0)
                throw new ArgumentException("@enum中没有枚举项，无法创建全局数据池", nameof(@enum));

            DataConfigurationEvent?.Invoke(DateTime.Now, $"配置“{enumname}”加入数据池");
            lock (_lock)
            {
                foreach (FieldInfo field in fields)
                {
                    string lookupKey = enumname + "." + field.Name;
                    if (!DataEnumLookup.ContainsKey(lookupKey))
                    {
                        int index = DataEnumLookup.Count;
                        DataEnumLookup[lookupKey] = index;
                        DataPool[index] = false;
                    }
                }
            }
        }

        /// <summary>
        /// 等待全局状态机
        /// </summary>
        /// <typeparam name="TEnum">状态机枚举</typeparam>
        /// <param name="input">枚举项</param>
        /// <param name="state">等待状态值</param>
        /// <param name="time">超时时间</param>
        /// <param name="token">取消令牌</param>
        /// <param name="onTimeout">超时回调</param>
        public static void AwaitEnum<TEnum>(TEnum input, bool state, CancellationToken token = default, int time = 0, Action<TEnum, bool, CancellationToken> onTimeout = null) where TEnum : Enum
        {
            string enumTypeName = typeof(TEnum).FullName;
            string lookupKey = enumTypeName + "." + input.ToString();
            int index;
            lock (_lock)
            {
                if (!DataEnumLookup.TryGetValue(lookupKey, out index)) return;
            }
            DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号状态为{state}");
            var current = Thread.CurrentThread;
            ProductionThreadInfo threadInfo;
            lock (_autoThLock) { threadInfo = _autoTh.Find(x => x.New_Thread == current); }
            Stopwatch stopwatch = Stopwatch.StartNew();
            do
            {
                if (token.IsCancellationRequested)
                {
                    DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号已被取消（{stopwatch.ElapsedMilliseconds}ms）");
                    token.ThrowIfCancellationRequested();
                }
                threadInfo?.Interrupt?.WaitOne();
                Thread.Sleep(50);
                if (time > 0 && stopwatch.ElapsedMilliseconds > time)
                {
                    DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号超时（{time}ms）");
                    onTimeout?.Invoke(input, state, token);
                }
            } while (Volatile.Read(ref DataPool[index]) != state);
            DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号状态为{state} 完成（{stopwatch.ElapsedMilliseconds}ms）");
        }

        /// <summary>
        /// 等待全局状态机
        /// </summary>
        /// <typeparam name="TEnum">状态机枚举</typeparam>
        /// <param name="input">枚举项</param>
        /// <param name="state">等待状态值</param>
        /// <param name="manual">外部状态标志</param>
        /// <param name="time">超时时间</param>
        /// <param name="token">取消令牌</param>
        public static void AwaitEnum<TEnum>(TEnum input, bool state, ManualResetEvent manual, int time = 0, CancellationToken token = default) where TEnum : Enum
        {
            string enumTypeName = typeof(TEnum).FullName;
            string lookupKey = enumTypeName + "." + input.ToString();
            int index;
            lock (_lock)
            {
                if (!DataEnumLookup.TryGetValue(lookupKey, out index)) return;
            }
            DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号状态为{state}");
            var current = Thread.CurrentThread;
            ProductionThreadInfo threadInfo;
            lock (_autoThLock) { threadInfo = _autoTh.Find(x => x.New_Thread == current); }
            Stopwatch stopwatch = Stopwatch.StartNew();
            do
            {
                if (token.IsCancellationRequested)
                {
                    DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号已被取消（{stopwatch.ElapsedMilliseconds}ms）");
                    token.ThrowIfCancellationRequested();
                }
                if (token.CanBeCanceled)
                {
                    WaitHandle.WaitAny(new[] { manual, token.WaitHandle });
                    token.ThrowIfCancellationRequested();
                }
                else
                {
                    manual.WaitOne();
                }
                threadInfo?.Interrupt?.WaitOne();
                Thread.Sleep(50);
                if (time > 0 && stopwatch.ElapsedMilliseconds > time)
                    break;
            } while (Volatile.Read(ref DataPool[index]) != state);
            DataConfigurationEvent?.Invoke(DateTime.Now, $"等待{enumTypeName}中{input}信号状态为{state} 完成（{stopwatch.ElapsedMilliseconds}ms）");

        }

        /// <summary>
        /// 设置全局状态机
        /// </summary>
        /// <typeparam name="TEnum">状态机枚举</typeparam>
        /// <param name="input">枚举项</param>
        /// <param name="state">设置状态</param>
        public static void SetEnum<TEnum>(TEnum input, bool state) where TEnum : Enum
        {
            string enumTypeName = typeof(TEnum).FullName;
            string lookupKey = enumTypeName + "." + input.ToString();
            lock (_lock)
            {
                if (DataEnumLookup.TryGetValue(lookupKey, out int index))
                {
                    DataConfigurationEvent?.Invoke(DateTime.Now, $"设置“{enumTypeName}”中“{input}”信号状态为“{state}”");
                    DataPool[index] = state;
                }
            }
        }

        public static void SetEnumBatch<TEnum>(IEnumerable<TEnum> inputs, bool state) where TEnum : Enum
        {
            string enumTypeName = typeof(TEnum).FullName;
            lock (_lock)
            {
                foreach (var input in inputs)
                {
                    string lookupKey = enumTypeName + "." + input.ToString();
                    if (DataEnumLookup.TryGetValue(lookupKey, out int index))
                    {
                        DataConfigurationEvent?.Invoke(
                            DateTime.Now,
                            $"设置“{enumTypeName}”中“{input}”信号状态为“{state}”");

                        DataPool[index] = state;
                    }
                }
            }
        }

        /// <summary>
        /// 获取全局状态机
        /// </summary>
        /// <typeparam name="TEnum">状态机枚举</typeparam>
        /// <param name="input">枚举项</param>
        /// <returns>枚举标签状态</returns>
        public static bool GetEnumValue<TEnum>(TEnum input) where TEnum : Enum
        {
            string lookupKey = typeof(TEnum).FullName + "." + input.ToString();
            lock (_lock)
            {
                if (DataEnumLookup.TryGetValue(lookupKey, out int index))
                    return DataPool[index];
            }
            return false;
        }

        /// <summary>
        /// 获取共享参数
        /// </summary>
        protected abstract void OnGetShared();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="thread"></param>
        public abstract void Initialize(ProcessBase thread);

        /// <summary>
        /// 自动运行
        /// </summary>
        /// <param name="thread">线程对象</param>
        [ProductionThread]
        protected abstract void Main(ProcessBase thread);

        /// <summary>
        /// 线程中断重置回调
        /// </summary>
        /// <param name="class_na">线程类名</param>
        /// <param name="thread">线程对象</param>
        /// <param name="ex">异常</param>
        protected abstract void ThreadRestartEvent(string class_na, ProcessBase thread, ThreadAbortException ex);

        /// <summary>
        /// 线程异常
        /// </summary>
        /// <param name="class_na">流程类名称</param>
        /// <param name="thread">线程对象</param>
        /// <param name="exception">异常</param>
        protected abstract void ThreadError(string class_na, ProcessBase thread, Exception exception);
    }
}
