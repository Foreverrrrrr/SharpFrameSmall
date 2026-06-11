using SharpFrameSmall.Common.SQL;
using SharpFrameSmall.log4Net;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace SharpFrameSmall.Common
{
    /// <summary>
    /// 生产信息类
    /// </summary>
    public static class ProductionInformation
    {
        private static Stopwatch stopwatch;
        private static TimeSpan totalElapsedTime = TimeSpan.Zero;
        private static Timer shiftTimer;
        private static bool shift8Triggered = false;
        private static bool shift20Triggered = false;
        private static readonly object shiftLock = new object();
        private static string TableName = "Produce_INFO";
        private static string SQLPath = "ProductionInformation.db";
        /// <summary>
        /// 换班事件
        /// </summary>
        public static event Action<string> ShiftChanged;

        /// <summary>
        /// 开始生产计时
        /// </summary>
        public static void StartProduction()
        {
            StartTiming();
            Log.Info($"生产计时开始: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} ");
        }

        /// <summary>
        /// 结束生产计时
        /// </summary>
        /// <returns>单次ct 累计ct</returns>
        public static (TimeSpan, TimeSpan) EndProduction()
        {
            var elapsedTime = EndTiming();
            totalElapsedTime += elapsedTime;
            Log.Info($"生产已结束。本次生产耗时: {elapsedTime.TotalMilliseconds} 毫秒。");
            Log.Info($"累计生产耗时: {totalElapsedTime.TotalMilliseconds} 毫秒。");
            return (elapsedTime, totalElapsedTime);
        }

        /// <summary>
        /// 获得累计生产时间
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetTotalProductionTime()
        {
            return totalElapsedTime;
        }

        private static void StartTiming()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private static TimeSpan EndTiming()
        {
            if (stopwatch != null && stopwatch.IsRunning)
            {
                stopwatch.Stop();
                return stopwatch.Elapsed;
            }
            return TimeSpan.Zero;
        }

        /// <summary>
        /// 读取生产信息
        /// </summary>
        public static void ReadProductionInfo(ref InfoStructure info)
        {
            string databasePath = SQLPath;
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string selectQuery = $"SELECT * FROM {TableName} WHERE date(SetTime) = @CurrentDate";
            SQLiteParameter parameter = new SQLiteParameter("@CurrentDate", currentDate);
            DataSet resultDataSet = SQL_Sqlite.ExecuteQuery(databasePath, selectQuery, parameter);
            if (resultDataSet != null && resultDataSet.Tables.Count > 0 && resultDataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = resultDataSet.Tables[0].Rows[0];
                info.SetTime = DateTime.Parse(row["SetTime"].ToString());
                info.ProductionTotal = Convert.ToInt32(row["ProductionTotal"]);
                info.QualifiedCount = Convert.ToInt32(row["QualifiedCount"]);
                info.NGCount = Convert.ToInt32(row["NGCount"]);
                info.YieldRate = Convert.ToDouble(row["YieldRate"]);
                info.ProductionTime = DateTime.Parse(row["ProductionTime"].ToString());
                info.ActualProductionTime = DateTime.Parse(row["ActualProductionTime"].ToString());
            }
            else
            {
                info = new InfoStructure();
            }
        }

        /// <summary>
        /// 保存生产信息
        /// </summary>
        public static void SaveProductionInfo(InfoStructure info)
        {
            string databasePath = SQLPath;
            string datePart = info.SetTime.ToString("yyyy-MM-dd");
            string selectQuery = $"SELECT COUNT(*) FROM {TableName} WHERE date(SetTime) = @DatePart";
            SQLiteParameter selectParam = new SQLiteParameter("@DatePart", datePart);
            object result = SQL_Sqlite.ExecuteScalar(databasePath, selectQuery, selectParam);
            int count = Convert.ToInt32(result);
            if (count > 0)
            {
                string deleteQuery = $"DELETE FROM {TableName} WHERE date(SetTime) = @DatePart";
                SQLiteParameter deleteParam = new SQLiteParameter("@DatePart", datePart);
                SQL_Sqlite.ExecuteNonQuery(databasePath, deleteQuery, deleteParam);
            }
            string insertQuery = $@"
            INSERT INTO {TableName} (SetTime, ProductionTotal, QualifiedCount, NGCount, YieldRate, ProductionTime, ActualProductionTime)
            VALUES (@SetTime, @ProductionTotal, @QualifiedCount, @NGCount, @YieldRate, @ProductionTime, @ActualProductionTime);";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
            new SQLiteParameter("@SetTime", info.SetTime.ToString("yyyy-MM-dd HH:mm:ss")),
            new SQLiteParameter("@ProductionTotal", info.ProductionTotal),
            new SQLiteParameter("@QualifiedCount", info.QualifiedCount),
            new SQLiteParameter("@NGCount", info.NGCount),
            new SQLiteParameter("@YieldRate", info.YieldRate),
            new SQLiteParameter("@ProductionTime", info.ProductionTime.ToString("yyyy-MM-dd HH:mm:ss")),
            new SQLiteParameter("@ActualProductionTime", info.ActualProductionTime.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            SQL_Sqlite.ExecuteNonQuery(databasePath, insertQuery, parameters);
        }

        /// <summary>
        /// 生成生产数据数据库
        /// </summary>
        public static void SetDataDB()
        {
            //SQL_Sqlite.NewSql(TableName + ".db");
            string createTableQuery = $@"
                    CREATE TABLE IF NOT EXISTS {TableName} (
                        SetTime TEXT,
                        ProductionTotal INTEGER,
                        QualifiedCount INTEGER,
                        NGCount INTEGER,
                        YieldRate REAL,
                        ProductionTime TEXT,
                        ActualProductionTime TEXT
                    );";
            //SQL_Sqlite.NewTable(TableName + ".db", TableName, createTableQuery);
            SQL_Sqlite.EnsureDatabaseAndTable(SQLPath, TableName, createTableQuery);
        }

        #region 换班
        /// <summary>
        /// 启动换班监控（每天 08:00:00 / 20:00:00 触发）
        /// </summary>
        public static void StartShiftWatcher(DateTime am_time,DateTime pm_time)
        {
            if (shiftTimer != null)
                return;
            string am = am_time.ToString("HH:mm:ss");
            string pm = pm_time.ToString("HH:mm:ss");
            shiftTimer = new Timer(300);
            shiftTimer.Elapsed += (s, e) => CheckShiftTime(s, e, am, pm);
            shiftTimer.AutoReset = true;
            shiftTimer.Enabled = true;
        }

        /// <summary>
        /// 停止换班监控
        /// </summary>
        public static void StopShiftWatcher()
        {
            if (shiftTimer == null)
                return;
            shiftTimer.Stop();
            shiftTimer.Elapsed -= (s, e) => CheckShiftTime(s, e, null, null);
            shiftTimer.Dispose();
            shiftTimer = null;
            shift8Triggered = false;
            shift20Triggered = false;
        }

        private static void CheckShiftTime(object sender, ElapsedEventArgs e, string am, string pm)
        {
            lock (shiftLock)
            {
                var now = DateTime.Now;
                string timeHMS = now.ToString("HH:mm:ss");
                if (timeHMS == am)
                {
                    if (!shift8Triggered)
                    {
                        shift8Triggered = true;
                        try
                        {
                            ShiftChanged?.Invoke(am);
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"ShiftChanged DayShiftStart 回调异常: {ex}");
                        }
                        Log.Info($"【换班事件】{am} 已触发（白班开始）");
                    }
                }
                else
                {
                    if (shift8Triggered && timeHMS != am)
                        shift8Triggered = false;
                }
                if (timeHMS == pm)
                {
                    if (!shift20Triggered)
                    {
                        shift20Triggered = true;
                        try
                        {
                            ShiftChanged?.Invoke(pm);
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"ShiftChanged NightShiftStart 回调异常: {ex}");
                        }
                        Log.Info($"【换班事件】{pm} 已触发（夜班开始）");
                    }
                }
                else
                {
                    if (shift20Triggered && timeHMS != pm)
                        shift20Triggered = false;
                }
            }
        }

        #endregion
    }

    public class InfoStructure
    {
        /// <summary>
        /// 设置时间
        /// </summary>
        public DateTime SetTime { get; set; }

        /// <summary>
        /// 生产总数
        /// </summary>
        public int ProductionTotal { get; set; }

        /// <summary>
        /// 合格数
        /// </summary>
        public int QualifiedCount { get; set; }

        /// <summary>
        /// NG数
        /// </summary>
        public int NGCount { get; set; }

        /// <summary>
        /// 良率
        /// </summary>
        public double YieldRate { get; set; }

        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime ProductionTime { get; set; }

        /// <summary>
        /// 实际生产时间
        /// </summary>
        public DateTime ActualProductionTime { get; set; }
    }
}
