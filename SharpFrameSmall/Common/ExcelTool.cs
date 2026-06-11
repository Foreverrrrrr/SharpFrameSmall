using log4net;
using log4net.Core;
using OfficeOpenXml;
using SharpFrameSmall.log4Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SharpFrameSmall.Common
{
    /// <summary>
    /// Excel列映射特性，标注属性对应的Excel列索引及行为
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelColumnAttribute : Attribute
    {
        /// <summary>
        /// 列索引 (0-based)
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 列标题名称（写入表头时使用），为空则用属性名
        /// </summary>
        public string HeaderName { get; set; }

        /// <summary>
        /// 是否为分组键（当前行为空时继承上一行的值）
        /// </summary>
        public bool IsGroupKey { get; set; }

        public ExcelColumnAttribute(int index)
        {
            Index = index;
        }
    }

    public class ExcelTool
    {

        public static readonly char[] _invisibleChars =
        {
            '\u200E', // LEFT-TO-RIGHT MARK
            '\u200F', // RIGHT-TO-LEFT MARK
            '\u202A', // LTR EMBEDDING
            '\u202B', // RTL EMBEDDING
            '\u202C', // POP DIRECTIONAL FORMATTING
            '\u202D', // LTR OVERRIDE
            '\u202E'  // RTL OVERRIDE
        };

        public struct PropertyStructure
        {
            public string TyName { get; set; }
            public object TyValue { get; set; }
            public Type TypeVert { get; set; }
        }

        private struct ColumnMapping
        {
            public PropertyInfo Property;
            public ExcelColumnAttribute Attribute;
        }

        #region 私有辅助方法

        /// <summary>
        /// 获取类型 T 上所有标记了 [ExcelColumn] 的属性映射，按列索引排序
        /// </summary>
        private static List<ColumnMapping> GetColumnMappings<T>()
        {
            return typeof(T).GetProperties()
                .Select(p => new { Prop = p, Attr = (ExcelColumnAttribute)p.GetCustomAttribute(typeof(ExcelColumnAttribute)) })
                .Where(x => x.Attr != null)
                .OrderBy(x => x.Attr.Index)
                .Select(x => new ColumnMapping { Property = x.Prop, Attribute = x.Attr })
                .ToList();
        }

        /// <summary>
        /// 清理路径中的不可见字符，规范化并关闭占用该文件的 Excel 进程
        /// </summary>
        private static string PrepareExcelPath(string path)
        {
            path = RemoveDirectionalChars(path);
            string normalizedPath = Path.GetFullPath(path);
            KillExcelProcess(normalizedPath);
            return normalizedPath;
        }

        /// <summary>
        /// 关闭正在占用指定文件的 Excel 进程
        /// </summary>
        private static void KillExcelProcess(string normalizedPath)
        {
            foreach (Process process in Process.GetProcessesByName("EXCEL"))
            {
                try
                {
                    if (process.MainWindowTitle == $"{normalizedPath} - Excel")
                        process.Kill();
                }
                catch { }
            }
        }

        #endregion

        #region 公共辅助方法

        /// <summary>
        /// 基于 [ExcelColumn] 特性复制对象的所有映射属性
        /// </summary>
        public static T CopyItem<T>(T source) where T : class, new()
        {
            T copy = new T();
            foreach (var p in typeof(T).GetProperties())
            {
                if (p.CanWrite && p.CanRead)
                    p.SetValue(copy, p.GetValue(source));
            }
            return copy;
        }

        /// <summary>
        /// 基于 [ExcelColumn] 特性比较两个对象的所有映射属性是否相同
        /// </summary>
        public static bool CompareItems<T>(T a, T b) where T : class, new()
        {
            List<ColumnMapping> mappings = GetColumnMappings<T>();
            foreach (var m in mappings)
            {
                string va = m.Property.GetValue(a)?.ToString();
                string vb = m.Property.GetValue(b)?.ToString();
                if (va != vb) return false;
            }
            return true;
        }

        /// <summary>
        /// 获取两个对象之间每个字段的具体差异
        /// 返回格式: "列名: 原始值 → 新值"
        /// </summary>
        public static List<string> GetItemDiffs<T>(T original, T modified) where T : class, new()
        {
            var diffs = new List<string>();
            List<ColumnMapping> mappings = GetColumnMappings<T>();
            foreach (var m in mappings)
            {
                string oldVal = m.Property.GetValue(original)?.ToString() ?? "";
                string newVal = m.Property.GetValue(modified)?.ToString() ?? "";
                if (oldVal != newVal)
                {
                    string header = !string.IsNullOrEmpty(m.Attribute.HeaderName)
                        ? m.Attribute.HeaderName : m.Property.Name;
                    diffs.Add($"{header}: \"{oldVal}\" → \"{newVal}\"");
                }
            }
            return diffs;
        }

        #endregion

        public static void WriteExcel<T>(string path, T testdata, int automatic_deletion = 180) where T : class
        {
            if (automatic_deletion > 0)
                CleanFile(path, automatic_deletion);
            if (testdata != null)
            {
                string excelsavepath = path + "\\" + DateTime.Now.ToString("yyyy-MM");
                if (!Directory.Exists(excelsavepath))
                    Directory.CreateDirectory(excelsavepath);
                Type datatype = typeof(T);
                PropertyInfo[] properties = datatype.GetProperties();
                System.Collections.Generic.List<PropertyStructure> structures = new System.Collections.Generic.List<PropertyStructure>();
                foreach (PropertyInfo property in properties)
                {
                    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)property.GetCustomAttribute(typeof(DescriptionAttribute));
                    PropertyStructure propertyStructure = new PropertyStructure();
                    propertyStructure.TyName = descriptionAttribute?.Description ?? property.Name;
                    propertyStructure.TyValue = property.GetValue(testdata);
                    propertyStructure.TypeVert = property.PropertyType;
                    structures.Add(propertyStructure);
                }
                string processName = "EXCEL";
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process process in processes)
                {
                    //string vat = process.MainWindowTitle.Replace("- Excel", "");
                    //if (vat == DateTime.Now.ToString("dd") + ".xlsx")
                    process.Kill();
                }
                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(excelsavepath + "\\" + DateTime.Now.ToString("dd") + ".xlsx")))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Count != 0 ? package.Workbook.Worksheets[1] : package.Workbook.Worksheets.Add("Form1");//是否存在工作表，不存在创建工作表
                    int rowCount = worksheet.Dimension != null ? worksheet.Dimension.End.Row : 0;//获取数据最后行
                    if (rowCount == 0)
                    {
                        for (int i = 0; i < structures.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = structures[i].TyName;
                            worksheet.Cells[1, i + 1].Style.Font.Name = "微软雅黑";
                        }
                        rowCount++;
                    }
                    for (int i = 0; i < structures.Count; i++)
                    {
                        if (structures[i].TypeVert == typeof(int))
                            worksheet.Cells[rowCount + 1, i + 1].Value = Convert.ToInt32(structures[i].TyValue);
                        else if (structures[i].TypeVert == typeof(double))
                            worksheet.Cells[rowCount + 1, i + 1].Value = Convert.ToDouble(structures[i].TyValue);
                        else if (structures[i].TypeVert == typeof(float))
                            worksheet.Cells[rowCount + 1, i + 1].Value = Convert.ToSingle(structures[i].TyValue);
                        else
                            worksheet.Cells[rowCount + 1, i + 1].Value = structures[i].TyValue.ToString();
                    }
                    package.SaveAs(new System.IO.FileInfo(excelsavepath + "\\" + DateTime.Now.ToString("dd") + ".xlsx"));
                }
            }
        }

        public static void WriteExcel<T>(string path, string excelname, ObservableCollection<T> data) where T : class
        {
            if (data != null && data.Count > 0)
            {
                if (Directory.Exists(path))
                {
                    string processName = "EXCEL";
                    Process[] processes = Process.GetProcessesByName(processName);
                    foreach (Process process in processes)
                    {
                        process.Kill();
                    }
                    using (ExcelPackage package = new ExcelPackage(new FileInfo(Path.Combine(path, excelname + ".xlsx"))))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Count != 0 ? package.Workbook.Worksheets[1] : package.Workbook.Worksheets.Add("Sheet1");
                        int rowCount = worksheet.Dimension != null ? worksheet.Dimension.End.Row : 0;
                        if (rowCount == 0)
                        {
                            Type dataType = typeof(T);
                            PropertyInfo[] properties = dataType.GetProperties();
                            for (int i = 0; i < properties.Length; i++)
                            {
                                DescriptionAttribute descriptionAttribute = (DescriptionAttribute)properties[i].GetCustomAttribute(typeof(DescriptionAttribute));
                                string propertyName = descriptionAttribute?.Description ?? properties[i].Name;
                                worksheet.Cells[1, i + 1].Value = propertyName;
                                worksheet.Cells[1, i + 1].Style.Font.Name = "微软雅黑";
                            }
                            rowCount++;
                        }
                        foreach (T item in data)
                        {
                            Type dataType = typeof(T);
                            PropertyInfo[] properties = dataType.GetProperties();
                            for (int i = 0; i < properties.Length; i++)
                            {
                                worksheet.Cells[rowCount + 1, i + 1].Value = properties[i].GetValue(item)?.ToString();
                            }
                            rowCount++;
                        }
                        package.Save();
                    }
                }
            }
        }

        public static void WriteExcel<T>(string path, ObservableCollection<T> data) where T : class
        {
            if (data == null || data.Count == 0) return;
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    throw new Exception("文件被占用，请关闭Excel后再试！");
                }
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault()
                                ?? package.Workbook.Worksheets.Add("Sheet1");
                var properties = typeof(T).GetProperties();
                int row = 1;
                for (int i = 0; i < properties.Length; i++)
                {
                    var desc = properties[i].GetCustomAttribute<DescriptionAttribute>();
                    string name = desc?.Description ?? properties[i].Name;

                    worksheet.Cells[row, i + 1].Value = name;
                    worksheet.Cells[row, i + 1].Style.Font.Name = "微软雅黑";
                }
                row++;
                foreach (var item in data)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[row, i + 1].Value =
                            properties[i].GetValue(item)?.ToString();
                    }
                    row++;
                }
                worksheet.Cells.AutoFitColumns();
                package.Save();
            }
        }
        public static string RemoveDirectionalChars(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            foreach (char c in _invisibleChars)
            {
                input = input.Replace(c.ToString(), string.Empty);
            }
            return input;
        }

        /// <summary>
        /// 通用 Excel 读取 — 根据 [ExcelColumn] 特性自动映射列到属性
        /// 支持分组键（IsGroupKey=true 的列，值为空时继承上一行）
        /// </summary>
        public static void ReadExcelData<T>(string path, string table, ref List<T> data) where T : class, new()
        {
            string normalizedPath = PrepareExcelPath(path);
            Log.Info($"读取excel:{path},table:{table}");

            using (ExcelPackage package = new ExcelPackage(new FileInfo(normalizedPath)))
            {
                var book = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == table);
                if (book == null)
                {
                    Log.Info($"工作表 {table} 不存在！");
                    return;
                }
                if (book.Dimension == null) return;

                object[,] values = book.Cells[1, 1, book.Dimension.End.Row, book.Dimension.End.Column].Value as object[,];
                if (values == null) return;

                List<ColumnMapping> mappings = GetColumnMappings<T>();
                if (mappings.Count == 0) return;
                ColumnMapping groupKeyMapping = default;
                bool hasGroupKey = false;
                int triggerColumnIndex = -1;
                foreach (var m in mappings)
                {
                    if (m.Attribute.IsGroupKey && !hasGroupKey)
                    {
                        groupKeyMapping = m;
                        hasGroupKey = true;
                    }
                    else if (triggerColumnIndex < 0)
                    {
                        triggerColumnIndex = m.Attribute.Index;
                    }
                }

                string groupKeyValue = string.Empty;
                int rows = values.GetLength(0);
                int cols = values.GetLength(1);
                for (int i = 1; i < rows; i++)
                {
                    bool allEmpty = true;
                    foreach (var m in mappings)
                    {
                        if (m.Attribute.Index < cols && values[i, m.Attribute.Index] != null
                            && !string.IsNullOrWhiteSpace(values[i, m.Attribute.Index].ToString()))
                        {
                            allEmpty = false;
                            break;
                        }
                    }
                    if (allEmpty) continue;

                    if (hasGroupKey)
                    {
                        string cellValue = values[i, groupKeyMapping.Attribute.Index]?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(cellValue))
                            groupKeyValue = cellValue;
                    }

                    T item = new T();
                    foreach (var m in mappings)
                    {
                        if (m.Attribute.IsGroupKey)
                        {
                            m.Property.SetValue(item, groupKeyValue);
                        }
                        else if (m.Attribute.Index < cols)
                        {
                            m.Property.SetValue(item, values[i, m.Attribute.Index]?.ToString()?.Trim());
                        }
                    }
                    data.Add(item);
                }
            }
        }

        /// <summary>
        /// 通用 Excel 更新 — 根据 [ExcelColumn] 更新指定行数据
        /// </summary>
        public static bool UpdateExcelData<T>(string path, string table, Dictionary<int, T> dataToUpdate) where T : class, new()
        {
            if (dataToUpdate == null) return false;
            string normalizedPath = PrepareExcelPath(path);
            if (!File.Exists(normalizedPath))
            {
                Log.Error($"Excel文件不存在: {normalizedPath}");
                return false;
            }
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(normalizedPath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == table);
                    if (worksheet == null)
                    {
                        Log.Error($"工作表 {table} 不存在！");
                        return false;
                    }
                    if (worksheet.Dimension == null)
                    {
                        Log.Error($"工作表 {table} 为空！");
                        return false;
                    }
                    List<ColumnMapping> mappings = GetColumnMappings<T>();
                    foreach (var kvp in dataToUpdate)
                    {
                        int rowIndex = kvp.Key;
                        T item = kvp.Value;
                        if (rowIndex <= 0 || rowIndex > worksheet.Dimension.End.Row)
                        {
                            Log.Error($"行索引 {rowIndex} 超出工作表范围，最大行数: {worksheet.Dimension.End.Row}");
                            return false;
                        }
                        foreach (var m in mappings)
                        {
                            worksheet.Cells[rowIndex, m.Attribute.Index + 1].Value = m.Property.GetValue(item)?.ToString();
                        }
                        Log.Info($"成功更新{table}第 {rowIndex} 行数据");
                    }
                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"更新Excel文件失败: {ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// 通用 Excel 写入 — 根据 [ExcelColumn] 特性自动映射属性到列
        /// </summary>
        public static void WriteExcelData<T>(string path, string table, List<T> data) where T : class, new()
        {
            if (data == null) return;
            string normalizedPath = PrepareExcelPath(path);

            using (ExcelPackage package = new ExcelPackage(new FileInfo(normalizedPath)))
            {
                var sheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == table)
                            ?? package.Workbook.Worksheets.Add(table);
                sheet.Cells.Clear();

                List<ColumnMapping> mappings = GetColumnMappings<T>();
                if (mappings.Count == 0) return;

                // 写入表头
                foreach (var m in mappings)
                {
                    string header = !string.IsNullOrEmpty(m.Attribute.HeaderName) ? m.Attribute.HeaderName : m.Property.Name;
                    sheet.Cells[1, m.Attribute.Index + 1].Value = header;
                    sheet.Cells[1, m.Attribute.Index + 1].Style.Font.Name = "微软雅黑";
                }

                // 写入数据行
                for (int i = 0; i < data.Count; i++)
                {
                    int row = i + 2;
                    foreach (var m in mappings)
                    {
                        object value = m.Property.GetValue(data[i]);
                        sheet.Cells[row, m.Attribute.Index + 1].Value = value?.ToString();
                    }
                }

                if (sheet.Dimension != null)
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                package.Save();
            }
            Log.Info($"写入Excel完成:{path},表:{table},共{data.Count}条数据");
        }


        /// <summary>
        /// 文件定时删除
        /// </summary>
        /// <param name="path"></param>
        public static void CleanFile(string path, int time, bool boolmes = false)
        {
            string pathcl = path;
            DirectoryInfo dir = new DirectoryInfo(pathcl);
            if (boolmes)
            {
                var files = dir.GetFiles();
                foreach (var file in files)
                {
                    if (file.CreationTime < DateTime.Now.AddDays(-time))
                        file.Delete();
                }
            }
            else
            {
                var files = dir.GetDirectories();
                foreach (var file in files)
                {
                    if (file.CreationTime < DateTime.Now.AddDays(-time))
                        file.Delete(true);
                }
            }
        }
    }
}

