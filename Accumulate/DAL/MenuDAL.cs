using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IDAL;

namespace DAL
{
    public class MenuDAL : IMenuDAL
    {
        public List<Menu> GetMenus()
        {
            string sql = @"SELECT ID,MenuName,ParentID,Link,CreateTime,UpdateTime,Sort,MenuStatus,
                        Remark FROM [dbo].[Menu] ORDER BY Sort ";
            using (var con = SqlHelper.GetConnection())
            {
                return con.Query<Menu>(sql).ToList();
            }
        }
        public int AddMenu(Menu menu)
        {
            using (var con = SqlHelper.GetConnection())
            {
                return con.Insert(menu);
            }
        }
    }
}
