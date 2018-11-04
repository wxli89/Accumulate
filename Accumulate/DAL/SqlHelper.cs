using Network;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Reflection;
using Comm;

namespace DAL
{
    public static class SqlHelper
    {
        private static readonly string constring = ConfigRead.Read("con");
        public static void SqlBulkCopyInsert(string tableName, DataTable dt)
        {
            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(constring))//引用SqlBulkCopy
                {
                    sqlRevdBulkCopy.DestinationTableName = tableName;//数据库中对应的表名
                    sqlRevdBulkCopy.NotifyAfter = dt.Rows.Count;//有几行数据
                    sqlRevdBulkCopy.WriteToServer(dt);//数据导入数据库
                    sqlRevdBulkCopy.Close();//关闭连接  
                }
            }
            catch (Exception ex)
            { }
        }
        public static IDbConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            return con;
        }
        public static int Insert<T>(this IDbConnection con, T t)
        {
            string sql = InsertSql(t);
            return con.Execute(sql, t);
        }
        private static string InsertSql<T>(T t)
        {
            if (null == t) return "";
            Type type = t.GetType();
            PropertyInfo[] pi = type.GetProperties().
                Where(
                p => p.GetCustomAttributes(typeof(IdentityAttribute)).Count() == 0
                ).ToArray<PropertyInfo>();
            string sql = "INSERT INTO " + type.Name + " VALUES(";
            foreach (var item in pi)
            {
                var a = item.GetCustomAttributes(typeof(IdentityAttribute));
                sql += "@" + item.Name + ",";
            }
            sql = sql.TrimEnd(',') + ")";
            return sql;
        }
    }
}
