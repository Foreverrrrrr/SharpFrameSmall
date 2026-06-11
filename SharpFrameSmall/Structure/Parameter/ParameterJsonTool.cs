using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpFrameSmall.Structure.Parameter
{
    /// <summary>
    /// 参数 JSON 工具 - 统一的参数持久化入口
    /// <para>职责：路径解析、JSON 读写、带验证的保存</para>
    /// </summary>
    public static class ParameterJsonTool
    {
        #region 路径解析（唯一的路径计算入口）

        /// <summary>
        /// 获取参数根目录
        /// </summary>
        public static string GetParameterDirectory()
        {
            string baseDir = Directory.GetParent(
                                AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'))
                            .FullName;
            return Path.Combine(baseDir, "Parameter");
        }

        /// <summary>
        /// 获取指定参数表的完整文件路径
        /// </summary>
        /// <param name="table">参数名称（不含 .json 后缀）</param>
        public static string GetFilePath(string table)
        {
            return Path.Combine(GetParameterDirectory(), table + ".json");
        }

        /// <summary>
        /// 确保参数目录存在
        /// </summary>
        private static string EnsureDirectory()
        {
            var dir = GetParameterDirectory();
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        #endregion

        #region 统一 Load / Save API

        /// <summary>
        /// 加载参数集合（反序列化）
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="table">参数表名称（不含 .json）</param>
        /// <returns>反序列化的对象，文件不存在返回 default</returns>
        public static T Load<T>(string table) where T : class
        {
            string filePath = GetFilePath(table);
            if (!File.Exists(filePath))
                return default;

            string json = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(json, DefaultSettings);
        }

        /// <summary>
        /// 保存参数集合（序列化）
        /// <para>直接写入，不做验证</para>
        /// </summary>
        /// <typeparam name="T">序列化类型</typeparam>
        /// <param name="table">参数表名称（不含 .json）</param>
        /// <param name="data">要保存的数据</param>
        /// <returns>是否成功写入</returns>
        public static bool Save<T>(string table, T data) where T : class
        {
            string filePath = GetFilePath(table);
            // 确保文件所在目录存在（支持配方子目录如 N2_1#/System.json）
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string json = JsonConvert.SerializeObject(data, DefaultSettings);
            string tempPath = filePath + ".tmp";

            // 先写入临时文件，再替换原文件（原子操作，防止断电导致文件损坏）
            File.WriteAllText(tempPath, json, Encoding.UTF8);

            if (File.Exists(filePath))
            {
                string backupPath = filePath + ".bak";
                File.Replace(tempPath, filePath, backupPath);
                try { File.Delete(backupPath); } catch { /* 备份清理失败不影响主流程 */ }
            }
            else
            {
                File.Move(tempPath, filePath);
            }

            return true;
        }

        /// <summary>
        /// 保存参数集合（带统一验证）
        /// <para>先对每个参数执行 ValidateAll()，全部通过后才写入</para>
        /// </summary>
        /// <typeparam name="T">ParameterBase 子类</typeparam>
        /// <param name="table">参数表名称</param>
        /// <param name="collection">参数集合</param>
        /// <param name="result">聚合的验证结果</param>
        /// <returns>true=验证通过且写入成功</returns>
        public static bool SaveWithValidation<T>(string table, IEnumerable<T> collection, out ValidationResult result)
            where T : ParameterBase
        {
            result = new ValidationResult();

            if (collection == null)
            {
                result.ParameterErrors.Add("参数集合为空，无法保存");
                return false;
            }

            // 统一验证：一次调用收集所有错误
            foreach (var param in collection)
            {
                var paramResult = param.ValidateAll();
                if (!paramResult.IsValid)
                {
                    foreach (var e in paramResult.ParameterErrors)
                        result.ParameterErrors.Add($"[{param.Name ?? $"ID={param.ID}"}] {e}");
                    foreach (var kv in paramResult.FieldErrors)
                        result.FieldErrors.Add(new KeyValuePair<string, string>(
                            $"{param.Name}.{kv.Key}", kv.Value));
                }
            }

            if (!result.IsValid)
                return false;

            return Save(table, collection);
        }

        #endregion

        #region 默认 JSON 配置

        /// <summary>
        /// 统一的 JSON 序列化设置
        /// </summary>
        public static readonly JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        };

        #endregion

        #region 配方目录

        /// <summary>
        /// 获取指定配方的目录路径
        /// </summary>
        /// <param name="recipeName">配方名称</param>
        public static string GetRecipeDirectory(string recipeName)
        {
            return Path.Combine(GetParameterDirectory(), recipeName);
        }

        /// <summary>
        /// 获取所有配方名称（即 Parameter 目录下的子目录名）
        /// </summary>
        public static List<string> GetRecipeNames()
        {
            var dir = GetParameterDirectory();
            if (!Directory.Exists(dir))
                return new List<string>();

            return Directory.GetDirectories(dir)
                .Select(d => Path.GetFileName(d))
                .OrderBy(n => n)
                .ToList();
        }

        /// <summary>
        /// 检查指定配方是否存在（目录存在且至少有一个 .json 文件）
        /// </summary>
        public static bool RecipeExists(string recipeName)
        {
            if (string.IsNullOrWhiteSpace(recipeName))
                return false;

            var dir = GetRecipeDirectory(recipeName);
            return Directory.Exists(dir)
                && Directory.GetFiles(dir, "*.json").Length > 0;
        }

        /// <summary>
        /// 检查系统中是否有任何配方存在
        /// </summary>
        public static bool HasAnyRecipe()
        {
            var recipes = GetRecipeNames();
            return recipes != null && recipes.Count > 0;
        }

        /// <summary>
        /// 删除整个配方目录
        /// </summary>
        public static void DeleteRecipe(string recipeName)
        {
            var dir = GetRecipeDirectory(recipeName);
            if (Directory.Exists(dir))
                Directory.Delete(dir, true);
        }

        /// <summary>
        /// 复制配方
        /// </summary>
        public static void CopyRecipe(string sourceRecipe, string targetRecipe)
        {
            var sourceDir = GetRecipeDirectory(sourceRecipe);
            var targetDir = GetRecipeDirectory(targetRecipe);
            if (!Directory.Exists(sourceDir))
                throw new DirectoryNotFoundException($"源配方目录不存在: {sourceDir}");
            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);
            foreach (var file in Directory.GetFiles(sourceDir, "*.json"))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)), true);
            }
        }

        #endregion

        #region JSON 文件管理

        /// <summary>
        /// 获取所有参数表名称（按文件名排序）
        /// </summary>
        public static List<string> GetAllTableNames()
        {
            var dir = GetParameterDirectory();
            if (!Directory.Exists(dir))
                return new List<string>();

            var files = new DirectoryInfo(dir).GetFiles("*.json");
            return files
                .Where(f => f.Name != "Base.json")
                .OrderBy(f =>
                {
                    var match = Regex.Match(Path.GetFileNameWithoutExtension(f.Name), @"_(\d+)#");
                    return match.Success ? int.Parse(match.Groups[1].Value) : int.MaxValue;
                })
                .Select(f => Path.GetFileNameWithoutExtension(f.Name))
                .ToList();
        }

        /// <summary>
        /// 从模板创建新参数表
        /// </summary>
        /// <param name="table">新表名称</param>
        /// <param name="template">模板名称（默认 "Base"）</param>
        public static void CreateFromTemplate(string table, string template = "Base")
        {
            var dir = EnsureDirectory();
            string source = Path.Combine(dir, template + ".json");
            string dest = Path.Combine(dir, table + ".json");
            File.Copy(source, dest, true);
        }

        /// <summary>
        /// 重命名参数表
        /// </summary>
        public static void RenameTable(string oldName, string newName)
        {
            if (Path.GetInvalidFileNameChars().Any(c => newName.Contains(c)))
                throw new ArgumentException($"文件名包含无效字符: {newName}");

            string oldPath = GetFilePath(oldName);
            string newPath = GetFilePath(newName);

            if (!File.Exists(oldPath))
                throw new FileNotFoundException($"源文件不存在: {oldPath}");
            if (File.Exists(newPath))
                throw new IOException($"目标文件已存在: {newPath}");

            File.Move(oldPath, newPath);
        }

        /// <summary>
        /// 删除参数表
        /// </summary>
        public static void DeleteTable(string table)
        {
            string path = GetFilePath(table);
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// 创建基础模板文件
        /// </summary>
        public static void CreateBaseTemplate<T>(T template) where T : class
        {
            var dir = EnsureDirectory();
            string path = Path.Combine(dir, "Base.json");
            string json = JsonConvert.SerializeObject(template, DefaultSettings);
            File.WriteAllText(path, json, Encoding.UTF8);
        }

        #endregion

        #region 批量操作

        /// <summary>
        /// 加载所有参数表为集合
        /// </summary>
        public static ObservableCollection<T> LoadAll<T>() where T : class
        {
            var dir = GetParameterDirectory();
            if (!Directory.Exists(dir))
                return new ObservableCollection<T>();

            var result = new ObservableCollection<T>();
            foreach (var file in new DirectoryInfo(dir).GetFiles("*.json"))
            {
                if (file.Name == "Base.json") continue;
                string json = File.ReadAllText(file.FullName, Encoding.UTF8);
                var item = JsonConvert.DeserializeObject<T>(json, DefaultSettings);
                if (item != null)
                    result.Add(item);
            }
            return result;
        }

        #endregion

        #region 工具方法

        /// <summary>
        /// IEnumerable → ObservableCollection 扩展
        /// </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }

        /// <summary>
        /// 序列化为 JSON 字符串
        /// </summary>
        public static string ToJson<T>(T data)
        {
            return JsonConvert.SerializeObject(data, DefaultSettings);
        }

        /// <summary>
        /// 从 JSON 字符串反序列化
        /// </summary>
        public static T FromJson<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, DefaultSettings);
        }

        #endregion
    }
}
