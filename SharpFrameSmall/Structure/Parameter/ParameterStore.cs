using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 参数仓储 - 配方级的参数集合管理
    /// <para>一个 ParameterStore 实例 = 一个配方的完整参数集</para>
    /// <para>包含多种不同类型的参数集合，作为一个整体加载/保存/切换</para>
    /// </summary>
    public class ParameterStore : INotifyPropertyChanged
    {
        #region 内部结构

        /// <summary>
        /// 注册条目：集合实例 + JSON 表名后缀 + 可选的默认工厂
        /// </summary>
        private class Entry
        {
            public object Collection { get; set; }
            public string TableSuffix { get; set; }
            public Type ParameterType { get; set; }
            /// <summary>默认参数工厂（返回 IEnumerable，首次无数据时使用）</summary>
            public Func<System.Collections.IEnumerable> DefaultFactory { get; set; }
        }

        /// <summary>
        /// 内部存储：参数类型 → 注册条目
        /// </summary>
        private readonly Dictionary<Type, Entry> _entries = new Dictionary<Type, Entry>();

        #endregion

        #region 构造 & 配方名

        /// <summary>
        /// 创建配方参数仓储
        /// </summary>
        /// <param name="recipeName">配方名称（如 "N2_1#"）</param>
        public ParameterStore(string recipeName)
        {
            RecipeName = recipeName ?? throw new ArgumentNullException(nameof(recipeName));
        }

        /// <summary>
        /// 无参构造（后续通过 SwitchRecipe 设置配方名）
        /// </summary>
        public ParameterStore() { }

        private string _recipeName;
        /// <summary>
        /// 当前配方名称
        /// </summary>
        public string RecipeName
        {
            get => _recipeName;
            private set
            {
                if (_recipeName != value)
                {
                    _recipeName = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isReady;
        /// <summary>
        /// 仓储是否已就绪（注册 + 加载完毕）
        /// <para>在完成所有 Register + LoadAll/LoadOrCreateDefaults 后调用 Ready() 标记为就绪</para>
        /// <para>ParameterDataGrid 会自动监听此属性，仅在就绪后才关联数据</para>
        /// </summary>
        public bool IsReady
        {
            get => _isReady;
            private set
            {
                if (_isReady != value)
                {
                    _isReady = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 标记仓储已就绪（注册 + 数据加载完毕后调用）
        /// <para>调用后 ParameterDataGrid 会自动关联集合数据</para>
        /// </summary>
        /// <example>
        /// var store = new ParameterStore("N2_1#");
        /// store.Register&lt;SystemParameter&gt;("System", ...);
        /// store.Register&lt;LabelParameter&gt;("Label", ...);
        /// store.LoadOrCreateDefaults();
        /// store.Ready();  // ← 通知 UI 可以绑定了
        /// </example>
        public void Ready()
        {
            IsReady = true;
        }

        #endregion

        #region 注册

        /// <summary>
        /// 注册一种参数类型及其 JSON 表名后缀
        /// <para>最终文件路径为：Parameter/{RecipeName}/{tableSuffix}.json</para>
        /// </summary>
        /// <typeparam name="T">ParameterBase 子类</typeparam>
        /// <param name="tableSuffix">JSON 文件名后缀（如 "System", "Label"）</param>
        /// <param name="defaultFactory">可选的默认参数工厂，首次无数据时自动生成</param>
        /// <example>
        /// // 注册时提供默认参数
        /// store.Register&lt;SystemParameter&gt;("System", () => new List&lt;SystemParameter&gt;
        /// {
        ///     new SystemParameter(1, "波特率", 9600),
        ///     new SystemParameter(2, "超时时间", 3000),
        /// });
        /// </example>
        public void Register<T>(string tableSuffix, Func<IEnumerable<T>> defaultFactory = null) where T : ParameterBase
        {
            if (string.IsNullOrWhiteSpace(tableSuffix))
                throw new ArgumentException("表名后缀不能为空", nameof(tableSuffix));

            var type = typeof(T);
            if (_entries.ContainsKey(type))
                throw new InvalidOperationException(
                    $"类型 {type.Name} 已注册（TableSuffix=\"{_entries[type].TableSuffix}\"），不能重复注册");

            _entries[type] = new Entry
            {
                Collection = new RangeObservableCollection<T>(),
                TableSuffix = tableSuffix,
                ParameterType = type,
                DefaultFactory = defaultFactory != null
                    ? (Func<System.Collections.IEnumerable>)(() => defaultFactory().ToList())
                    : null
            };
        }

        /// <summary>
        /// 注册一种参数类型（使用类型名作为默认表名后缀）
        /// <para>例如 Register&lt;SystemParameter&gt;() → 表名后缀 "SystemParameter"</para>
        /// </summary>
        /// <param name="defaultFactory">可选的默认参数工厂</param>
        public void Register<T>(Func<IEnumerable<T>> defaultFactory = null) where T : ParameterBase
        {
            Register<T>(typeof(T).Name, defaultFactory);
        }

        #endregion

        #region 集合访问

        /// <summary>
        /// 获取指定类型的参数集合
        /// </summary>
        public RangeObservableCollection<T> Get<T>() where T : ParameterBase
        {
            if (_entries.TryGetValue(typeof(T), out var entry))
                return (RangeObservableCollection<T>)entry.Collection;
            throw new InvalidOperationException(
                $"类型 {typeof(T).Name} 未注册，请先调用 Register<{typeof(T).Name}>()");
        }

        /// <summary>
        /// 按名称查询参数
        /// </summary>
        public T QueryByName<T>(string name) where T : ParameterBase
        {
            var result = Get<T>().FirstOrDefault(p => p.Name == name);
            if (result == null)
                throw new ArgumentException($"配方 \"{RecipeName}\" 中不存在名称为 \"{name}\" 的 {typeof(T).Name}");
            return result;
        }

        /// <summary>
        /// 按条件查询（返回第一个匹配，无则 null）
        /// </summary>
        public T Query<T>(Func<T, bool> predicate) where T : ParameterBase
        {
            return Get<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 按条件查询所有匹配项
        /// </summary>
        public IEnumerable<T> QueryAll<T>(Func<T, bool> predicate) where T : ParameterBase
        {
            return Get<T>().Where(predicate);
        }

        /// <summary>
        /// 替换指定类型的集合数据
        /// </summary>
        public void Update<T>(IEnumerable<T> source) where T : ParameterBase
        {
            Get<T>().ReplaceRange(source);
        }

        #endregion

        #region 按键访问（供 UI 控件非泛型使用）

        /// <summary>
        /// 通过 TableSuffix 查找注册条目
        /// </summary>
        private Entry GetEntryByKey(string tableSuffix)
        {
            return _entries.Values.FirstOrDefault(e =>
                string.Equals(e.TableSuffix, tableSuffix, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 获取所有已注册的 TableSuffix 键列表
        /// </summary>
        public IEnumerable<string> RegisteredKeys => _entries.Values.Select(e => e.TableSuffix);

        /// <summary>
        /// 通过 TableSuffix 获取参数集合（非泛型，返回 IList）
        /// <para>主要供 ParameterDataGrid 等 UI 控件绑定使用</para>
        /// </summary>
        /// <param name="tableSuffix">注册时的表名后缀（如 "System"）</param>
        public IList GetCollectionByKey(string tableSuffix)
        {
            var entry = GetEntryByKey(tableSuffix);
            return entry != null ? (IList)entry.Collection : null;
        }

        /// <summary>
        /// 判断指定 TableSuffix 是否已注册
        /// </summary>
        public bool HasKey(string tableSuffix)
        {
            return GetEntryByKey(tableSuffix) != null;
        }

        /// <summary>
        /// 通过 TableSuffix 获取对应的参数类型
        /// </summary>
        public Type GetParameterTypeByKey(string tableSuffix)
        {
            var entry = GetEntryByKey(tableSuffix);
            return entry?.ParameterType;
        }

        /// <summary>
        /// 通过 TableSuffix 创建一个新的参数实例（ID 自动递增）
        /// <para>供 UI 控件的"添加参数"功能使用</para>
        /// </summary>
        public ParameterBase CreateParameter(string tableSuffix)
        {
            var entry = GetEntryByKey(tableSuffix);
            if (entry == null)
                throw new InvalidOperationException($"未找到 TableSuffix=\"{tableSuffix}\" 的注册类型");

            var param = (ParameterBase)Activator.CreateInstance(entry.ParameterType);

            // 自动计算 ID = 集合中最大 ID + 1
            var collection = (IList)entry.Collection;
            int maxId = 0;
            foreach (var item in collection)
            {
                if (item is ParameterBase p && p.ID > maxId)
                    maxId = p.ID;
            }
            param.ID = maxId + 1;
            param.Name = $"New_{param.ID}";

            return param;
        }

        /// <summary>
        /// 通过 TableSuffix 保存单个类型（不验证）
        /// </summary>
        public bool SaveByKey(string tableSuffix)
        {
            var entry = GetEntryByKey(tableSuffix);
            if (entry == null) return false;
            SaveEntry(entry);
            return true;
        }

        /// <summary>
        /// 通过 TableSuffix 保存单个类型（带验证）
        /// </summary>
        public bool SaveByKeyWithValidation(string tableSuffix, out ValidationResult result)
        {
            result = new ValidationResult();
            var entry = GetEntryByKey(tableSuffix);
            if (entry == null)
            {
                result.ParameterErrors.Add($"未找到 TableSuffix=\"{tableSuffix}\" 的注册类型");
                return false;
            }

            ValidateEntry(entry, result);
            if (!result.IsValid)
                return false;

            SaveEntry(entry);
            return true;
        }

        #endregion

        #region 配方级 Load / Save（核心：整体操作）

        /// <summary>
        /// 获取指定类型的完整 JSON 文件表名
        /// <para>格式：{RecipeName}/{TableSuffix}</para>
        /// </summary>
        private string GetTableName(Entry entry)
        {
            if (string.IsNullOrEmpty(RecipeName))
                return entry.TableSuffix;
            return RecipeName + "/" + entry.TableSuffix;
        }

        /// <summary>
        /// 一键加载整个配方（所有注册类型）
        /// </summary>
        public void LoadAll()
        {
            foreach (var kv in _entries)
            {
                LoadEntry(kv.Value);
            }
        }

        /// <summary>
        /// 加载单个类型
        /// </summary>
        public void Load<T>() where T : ParameterBase
        {
            if (_entries.TryGetValue(typeof(T), out var entry))
                LoadEntry(entry);
        }

        /// <summary>
        /// 加载单个类型（指定表名覆盖）
        /// </summary>
        public void Load<T>(string table) where T : ParameterBase
        {
            var data = ParameterJsonTool.Load<List<T>>(table);
            if (data != null)
                Update<T>(data);
        }

        /// <summary>
        /// 内部：加载一个注册条目
        /// <para>若文件不存在且注册了默认工厂，则自动使用默认数据填充</para>
        /// </summary>
        private void LoadEntry(Entry entry)
        {
            var tableName = GetTableName(entry);
            // 通过反射调用泛型 Load
            var method = typeof(ParameterJsonTool)
                .GetMethod(nameof(ParameterJsonTool.Load))
                .MakeGenericMethod(typeof(List<>).MakeGenericType(entry.ParameterType));
            var data = method.Invoke(null, new object[] { tableName });

            // 文件不存在时回退到默认工厂
            if (data == null && entry.DefaultFactory != null)
            {
                data = entry.DefaultFactory();
            }

            if (data != null)
            {
                var collection = entry.Collection;
                var replaceMethod = collection.GetType().GetMethod("ReplaceRange");
                replaceMethod?.Invoke(collection, new[] { data });
            }
        }

        /// <summary>
        /// 一键保存整个配方（带验证，所有类型统一验证后才写入）
        /// </summary>
        /// <returns>聚合验证结果</returns>
        public ValidationResult SaveAll()
        {
            var totalResult = new ValidationResult();

            // 第一遍：验证所有类型
            foreach (var kv in _entries)
            {
                ValidateEntry(kv.Value, totalResult);
            }

            // 有错误时不写入任何文件
            if (!totalResult.IsValid)
                return totalResult;

            // 第二遍：全部通过后再写入
            foreach (var kv in _entries)
            {
                SaveEntry(kv.Value);
            }

            return totalResult;
        }

        /// <summary>
        /// 一键保存整个配方（不验证）
        /// </summary>
        public void SaveAllDirect()
        {
            foreach (var kv in _entries)
            {
                SaveEntry(kv.Value);
            }
        }

        /// <summary>
        /// 保存单个类型（带验证）
        /// </summary>
        public bool SaveWithValidation<T>(out ValidationResult result) where T : ParameterBase
        {
            if (!_entries.TryGetValue(typeof(T), out var entry))
                throw new InvalidOperationException($"类型 {typeof(T).Name} 未注册");

            var tableName = GetTableName(entry);
            return ParameterJsonTool.SaveWithValidation(tableName, Get<T>(), out result);
        }

        /// <summary>
        /// 保存单个类型（不验证）
        /// </summary>
        public bool Save<T>() where T : ParameterBase
        {
            if (!_entries.TryGetValue(typeof(T), out var entry))
                throw new InvalidOperationException($"类型 {typeof(T).Name} 未注册");

            return ParameterJsonTool.Save(GetTableName(entry), Get<T>());
        }

        /// <summary>
        /// 内部：验证一个注册条目中所有参数
        /// </summary>
        private void ValidateEntry(Entry entry, ValidationResult totalResult)
        {
            var collection = entry.Collection as System.Collections.IEnumerable;
            if (collection == null) return;

            foreach (var item in collection)
            {
                if (item is ParameterBase param)
                {
                    var paramResult = param.ValidateAll();
                    if (!paramResult.IsValid)
                    {
                        foreach (var e in paramResult.ParameterErrors)
                            totalResult.ParameterErrors.Add($"[{entry.TableSuffix}/{param.Name ?? $"ID={param.ID}"}] {e}");
                        foreach (var kv in paramResult.FieldErrors)
                            totalResult.FieldErrors.Add(new KeyValuePair<string, string>(
                                $"{entry.TableSuffix}/{param.Name}.{kv.Key}", kv.Value));
                    }
                }
            }
        }

        /// <summary>
        /// 内部：保存一个注册条目到 JSON
        /// </summary>
        private void SaveEntry(Entry entry)
        {
            var tableName = GetTableName(entry);
            var method = typeof(ParameterJsonTool)
                .GetMethod(nameof(ParameterJsonTool.Save))
                .MakeGenericMethod(entry.Collection.GetType());
            method.Invoke(null, new object[] { tableName, entry.Collection });
        }

        #endregion

        #region 默认配方生成

        /// <summary>
        /// 检查当前配方是否已有 JSON 数据文件
        /// <para>检查逻辑：配方目录存在 且 至少包含一个已注册类型的 .json 文件</para>
        /// </summary>
        public bool HasRecipeData()
        {
            if (string.IsNullOrEmpty(RecipeName))
                return false;

            var recipeDir = ParameterJsonTool.GetRecipeDirectory(RecipeName);
            if (!System.IO.Directory.Exists(recipeDir))
                return false;

            // 检查是否有至少一个已注册类型对应的 JSON 文件
            foreach (var entry in _entries.Values)
            {
                var filePath = ParameterJsonTool.GetFilePath(GetTableName(entry));
                if (System.IO.File.Exists(filePath))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 使用注册时提供的默认工厂填充所有集合
        /// <para>仅对提供了 defaultFactory 的类型生效</para>
        /// </summary>
        public void InitializeDefaults()
        {
            foreach (var entry in _entries.Values)
            {
                if (entry.DefaultFactory != null)
                {
                    var data = entry.DefaultFactory();
                    if (data != null)
                    {
                        var replaceMethod = entry.Collection.GetType().GetMethod("ReplaceRange");
                        replaceMethod?.Invoke(entry.Collection, new object[] { data });
                    }
                }
            }
        }

        /// <summary>
        /// 加载配方 - 若无数据则自动生成默认参数并保存
        /// <para>推荐在程序启动时使用此方法代替 LoadAll()</para>
        /// </summary>
        /// <returns>true=从文件加载的现有数据，false=使用默认值新建的</returns>
        /// <example>
        /// var store = new ParameterStore("N2_1#");
        /// store.Register&lt;SystemParameter&gt;("System", () => new List&lt;SystemParameter&gt;
        /// {
        ///     new SystemParameter(1, "波特率", 9600),
        ///     new SystemParameter(2, "超时时间", 3000),
        /// });
        /// store.Register&lt;LabelParameter&gt;("Label");
        /// 
        /// // 首次启动会自动创建默认参数并保存，后续启动直接加载
        /// bool isExisting = store.LoadOrCreateDefaults();
        /// </example>
        public bool LoadOrCreateDefaults()
        {
            if (HasRecipeData())
            {
                LoadAll();
                return true;
            }

            // 无数据 → 用默认工厂填充
            InitializeDefaults();
            // 持久化到磁盘（下次启动就是 LoadAll 加载了）
            SaveAllDirect();
            return false;
        }

        /// <summary>
        /// 静态辅助：确保系统中至少存在一个默认配方
        /// <para>检查全局是否有任何配方存在，若没有则用 configureStore 创建默认配方</para>
        /// </summary>
        /// <param name="defaultRecipeName">默认配方名称（如 "Default"）</param>
        /// <param name="configureStore">配置回调：在此注册类型和默认工厂</param>
        /// <returns>创建或加载好的 ParameterStore</returns>
        /// <example>
        /// var store = ParameterStore.EnsureDefaultRecipe("Default", s =>
        /// {
        ///     s.Register&lt;SystemParameter&gt;("System", () => new List&lt;SystemParameter&gt;
        ///     {
        ///         new SystemParameter(1, "波特率", 9600),
        ///         new SystemParameter(2, "超时时间", 3000),
        ///         new SystemParameter(3, "通讯端口", "COM1"),
        ///     });
        ///     s.Register&lt;LabelParameter&gt;("Label", () => new List&lt;LabelParameter&gt;
        ///     {
        ///         new LabelParameter(1, "默认标签",
        ///             new ParameterField("Content", "Hello"),
        ///             new ParameterField("FontSize", 12, "pt")),
        ///     });
        ///     s.Register&lt;AttdefParameter&gt;("Attdef");
        ///     s.Register&lt;ModbusParameter&gt;("Modbus");
        /// });
        /// </example>
        public static ParameterStore EnsureDefaultRecipe(string defaultRecipeName, Action<ParameterStore> configureStore)
        {
            if (string.IsNullOrWhiteSpace(defaultRecipeName))
                throw new ArgumentException("默认配方名称不能为空", nameof(defaultRecipeName));
            if (configureStore == null)
                throw new ArgumentNullException(nameof(configureStore));

            var store = new ParameterStore(defaultRecipeName);
            configureStore(store);

            // 如果全局没有任何配方 → 创建默认配方
            var existingRecipes = ParameterJsonTool.GetRecipeNames();
            if (existingRecipes == null || existingRecipes.Count == 0)
            {
                store.InitializeDefaults();
                store.SaveAllDirect();
            }
            else
            {
                // 有配方 → 加载第一个已有配方（或指定的默认配方）
                var targetRecipe = existingRecipes.Contains(defaultRecipeName)
                    ? defaultRecipeName
                    : existingRecipes[0];
                store.RecipeName = targetRecipe;
                store.LoadAll();
            }

            return store;
        }

        #endregion

        #region 配方切换

        /// <summary>
        /// 切换到另一个配方（自动加载新配方数据）
        /// </summary>
        /// <param name="newRecipeName">新配方名称</param>
        public void SwitchRecipe(string newRecipeName)
        {
            RecipeName = newRecipeName ?? throw new ArgumentNullException(nameof(newRecipeName));
            LoadAll();
        }

        /// <summary>
        /// 从当前配方复制到新配方
        /// </summary>
        /// <param name="newRecipeName">新配方名称</param>
        public void CopyTo(string newRecipeName)
        {
            var savedRecipe = RecipeName;
            try
            {
                RecipeName = newRecipeName;
                SaveAllDirect();
            }
            finally
            {
                RecipeName = savedRecipe;
            }
        }

        #endregion

        #region 元信息

        /// <summary>
        /// 检查某种类型是否已注册
        /// </summary>
        public bool IsRegistered<T>() where T : ParameterBase
        {
            return _entries.ContainsKey(typeof(T));
        }

        /// <summary>
        /// 获取所有已注册的类型
        /// </summary>
        public IEnumerable<Type> RegisteredTypes => _entries.Keys;

        /// <summary>
        /// 获取注册类型的数量
        /// </summary>
        public int RegisteredCount => _entries.Count;

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
