using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IDAL;
using Comm;

namespace DAL
{
    public class MenuDAL : IMenuDAL
    {
        public List<Menu> GetMenus()
        {
            string sql = @"SELECT ID,MenuName,ParentID,Link,CreateTime,UpdateTime,Sort,MenuStatus,
                        Remark FROM [dbo].[Menu] ORDER BY Sort ";
            return SqlHelper.ExecuteRead((con) => con.Query<Menu>(sql).ToList());
        }
        public int AddMenu(Menu menu)
        {
            return SqlHelper.ExecuteWrite((con) => con.Insert(menu));
        }
        public int DelMenu(IList<int> ids)
        {
            string sql = "DELETE Menu WHERE ID IN @ids";
            return SqlHelper.ExecuteWrite((con) => con.Execute(sql, new { ids = ids }));
        }
        public int UpdateMenu(Menu menu)
        {
            return 1;
        }
        public PageModel<T> Paging<T>(string TableName, int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            return SqlHelper.ExecuteRead((con) => con.Paging<T>(TableName, PageSize, PageIndex, OrderBy, Where));
        }
    }
}
