using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlHelper
    {
        private static readonly string constring = ConfigurationManager.AppSettings["con"];
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
    }
}
