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
            string sql = "SELECT MenuName,ParentID,Link FROM [dbo].[Menu] WHERE MenuStatus = 1 ORDER BY Sort ";
            using (var con = SqlHelper.GetConnection())
            {
                return con.Query<Menu>(sql).ToList();
            }
        }
    }
}
