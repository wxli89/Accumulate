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
        /// <summary>
        /// 对象插入表
        /// </summary>
        /// <typeparam name="T">类名须与表同名</typeparam>
        /// <param name="con"></param>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static int Insert<T>(this IDbConnection con, T t)
        {
            string sql = CreateInsert(t);
            return con.Execute(sql, t);
        }
        public static PageModel<T> Paging<T>(this IDbConnection con, string TableName, int PageSize, int PageIndex, string OrderBy, string Where)
        {
            string sql = CreatePaging(TableName, PageSize, PageIndex, OrderBy, Where);
            var mult = con.QueryMultiple(sql, new { PageSize = PageSize, PageIndex = PageIndex });
            PageModel<T> page = new PageModel<T>();
            page.Data = mult.Read<T>().ToList();
            page.PageInfo = mult.Read<PageInfo>().First();
            page.PageInfo.PageCount = page.PageInfo.Total % page.PageInfo.PageSize == 0 ?
                                      page.PageInfo.Total / page.PageInfo.PageSize :
                                      page.PageInfo.Total / page.PageInfo.PageSize + 1;
            return page;
        }

        private static string CreatePaging(string TableName, int PageSize, int PageIndex, string OrderBy, string Where)
        {
            string sql = @"SELECT * FROM 
                                (SELECT *,ROW_NUMBER() OVER(ORDER BY {0}) r FROM {1} WHERE 1=1 {2} ) A 
                                WHERE A.r > @PageSize * (@PageIndex - 1) AND A.r <= @PageSize * @PageIndex;
                           SELECT COUNT(1) Total,PageSize=@PageSize FROM {1} WHERE 1=1 {2}; ";
            sql = string.Format(sql, OrderBy, TableName, Where);
            return sql;
        }
        /// <summary>
        /// 构造Inser SQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private static string CreateInsert<T>(T t)
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
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="action"></param>
        public static int ExecuteWrite(Func<IDbConnection, int> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            using (IDbConnection con = GetConnection())
            {
                return action(con);
            }
        }
        /// <summary>
        /// 查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T ExecuteRead<T>(Func<IDbConnection, T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            using (IDbConnection con = GetConnection())
            {
                return action(con);
            }
        }
    }
}
