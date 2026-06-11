using SharpFrameSmall.Common.SQL;
using SharpFrameSmall.ViewModels.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SharpFrameSmall.Common
{
    public static class UserManagement
    {
        private static string TableName = "User_INFO";
        private static string SQLPath = "ProductionInformation.db";

        /// <summary>
        /// 创建用户账户
        /// </summary>
        /// <param name="user">用户信息</param>
        public static bool CreateUser(User user)
        {
            string sql = $"INSERT INTO {TableName} (Name,PassWord,Level) VALUES (@Name,@PassWord,@Level)";
            return SQL_Sqlite.ExecSQL(SQLPath, sql,
                new SQLiteParameter("@Name", user.Name),
                new SQLiteParameter("@PassWord", user.PassWord),
                new SQLiteParameter("@Level", (int)user.Level)
            );
        }

        /// <summary>
        /// 创建用户账户
        /// </summary>
        /// <param name="user">用户信息</param>
        public static bool CreateUser(string username, string password)
        {
            if (Enum.TryParse<UserLevel>(username, out var level))
            {
                int value = (int)level;
            }
            string sql = $"INSERT INTO {TableName} (Name,PassWord,Level) VALUES (@Name,@PassWord,@Level)";
            return SQL_Sqlite.ExecSQL(SQLPath, sql,
                new SQLiteParameter("@Name", username),
                new SQLiteParameter("@PassWord", password),
                new SQLiteParameter("@Level", (int)level)
            );
        }

        /// <summary>
        /// 修改用户名称或密码
        /// </summary>
        /// <param name="user">原用户信息</param>
        /// <param name="newuser">新用户信息</param>
        public static bool ModifyUserInformation(User oldUser, User newUser)
        {
            string sql = $"UPDATE {TableName} SET Name = @NewName,PassWord = @NewPassWord,Level = @NewLevel WHERE Name = @OldName";
            return SQL_Sqlite.ExecSQL(
                SQLPath,
                sql,
                new SQLiteParameter("@NewName", newUser.Name),
                new SQLiteParameter("@NewPassWord", newUser.PassWord),
                new SQLiteParameter("@NewLevel", (int)oldUser.Level),
                new SQLiteParameter("@OldName", oldUser.Name)
            );
        }

        /// <summary>
        /// 修改用户信息（用户名或密码或等级）
        /// </summary>
        /// <param name="oldUserName">旧用户名</param>
        /// <param name="newUserName">新用户名，可为空表示不修改</param>
        /// <param name="newPassword">新密码，可为空表示不修改</param>
        /// <param name="newLevel">新权限等级，可为空表示不修改</param>
        public static bool ModifyUserInformation(
            string oldUserName,
            string newUserName = null,
            string newPassword = null,
            UserLevel? newLevel = null)
        {
            List<string> setClauses = new List<string>();
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();

            if (!string.IsNullOrEmpty(newUserName))
            {
                setClauses.Add("Name = @NewName");
                parameters.Add(new SQLiteParameter("@NewName", newUserName));
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                setClauses.Add("PassWord = @NewPassWord");
                parameters.Add(new SQLiteParameter("@NewPassWord", newPassword));
            }

            if (newLevel.HasValue)
            {
                setClauses.Add("Level = @NewLevel");
                parameters.Add(new SQLiteParameter("@NewLevel", (int)newLevel.Value));
            }

            if (setClauses.Count == 0)
            {
                return false;
            }
            string setClause = string.Join(",", setClauses);
            string sql = $"UPDATE {TableName} SET {setClause} WHERE Name = @OldName";
            parameters.Add(new SQLiteParameter("@OldName", oldUserName));
            return SQL_Sqlite.ExecSQL(SQLPath, sql, parameters.ToArray());
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        public static bool DeleteUser(User user)
        {
            if (user.Level == UserLevel.Admin)
            {
                int adminCount = GetAllUser().Count(u => u.Level == UserLevel.Admin);

                if (adminCount <= 1)
                    throw new Exception("至少保留一个管理员！");
            }
            string sql = $"DELETE FROM {TableName} WHERE Name=@Name";
            return SQL_Sqlite.ExecSQL(SQLPath, sql,
                new SQLiteParameter("@Name", user.Name)
            );
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        public static bool DeleteUser(string name)
        {
            if (name == UserLevel.Admin.ToString())
            {
                int adminCount = GetAllUser().Count(u => u.Level == UserLevel.Admin);

                if (adminCount <= 1)
                    throw new Exception("至少保留管理员！");
            }
            if (name == UserLevel.Operator.ToString())
            {
                int adminCount = GetAllUser().Count(u => u.Level == UserLevel.Admin);

                if (adminCount <= 1)
                    throw new Exception("至少保留操作员！");
            }
            string sql = $"DELETE FROM {TableName} WHERE Name=@Name";
            return SQL_Sqlite.ExecSQL(SQLPath, sql,
                new SQLiteParameter("@Name", name)
            );
        }

        /// <summary>
        /// 用户登入
        /// </summary>
        /// <param name="usernaeme">用户名称</param>
        /// <param name="password">用户密码</param>
        public static User LoginUser(string username, string password)
        {
            string sql = $"SELECT Name,PassWord,Level FROM {TableName} WHERE Name = @Name AND PassWord = @PassWord";
            var ds = SQL_Sqlite.ExecuteQuery(SQLPath, sql,
                        new SQLiteParameter("@Name", username),
                          new SQLiteParameter("@PassWord", password)
                          );
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                return new User
                {
                    Name = row["Name"].ToString(),
                    PassWord = row["PassWord"].ToString(),
                    Level = (UserLevel)Convert.ToInt32(row["Level"])
                };
            }
            return null;
        }

        /// <summary>
        /// 用户登入
        /// </summary>
        /// <param name="usernaeme">用户名称</param>
        /// <param name="password">用户密码</param>
        public static User LoginUser(User user)
        {
            string sql = $"SELECT Name,PassWord,Level FROM {TableName} WHERE Name = @Name AND PassWord = @PassWord";
            var ds = SQL_Sqlite.ExecuteQuery(SQLPath, sql,
                        new SQLiteParameter("@Name", user.Name),
                          new SQLiteParameter("@PassWord", user.PassWord)
                          );
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                return new User
                {
                    Name = row["Name"].ToString(),
                    PassWord = row["PassWord"].ToString(),
                    Level = (UserLevel)Convert.ToInt32(row["Level"])
                };
            }
            return null;
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUser()
        {
            List<User> users = new List<User>();
            string sql = $"SELECT Name,PassWord,Level FROM {TableName}";
            var ds = SQL_Sqlite.ExecuteQuery(SQLPath, sql);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    users.Add(new User
                    {
                        Name = row["Name"].ToString(),
                        PassWord = row["PassWord"].ToString(),
                        Level = (UserLevel)Convert.ToInt32(row["Level"])
                    });
                }
            }
            return users;
        }

        /// <summary>
        /// 创建用户管理数据库
        /// </summary>
        public static void SetUseDB()
        {
            string createTableQuery = $@"CREATE TABLE IF NOT EXISTS {TableName} (
            Name TEXT PRIMARY KEY,
            PassWord TEXT NOT NULL,
            Level INTEGER NOT NULL );";
            SQL_Sqlite.EnsureDatabaseAndTable(SQLPath, TableName, createTableQuery);
            string checkSql = $"SELECT COUNT(*) FROM {TableName}";
            var ds = SQL_Sqlite.ExecuteQuery(SQLPath, checkSql);

            int count = 0;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            if (count == 0)
            {
                CreateDefaultUsers();
            }
        }

        private static void CreateDefaultUsers()
        {
            // 默认管理员
            CreateUser(new User
            {
                Name = UserLevel.Admin.ToString(),
                PassWord = "kskt2026",
                Level = UserLevel.Admin
            });

            // 默认操作员
            CreateUser(new User
            {
                Name = UserLevel.Operator.ToString(),
                PassWord = "12345",
                Level = UserLevel.Operator
            });
        }
    }
}
