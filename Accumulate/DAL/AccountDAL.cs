using AdminModel;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL : IAccountDAL
    {
        public int SystemRegist(string guid)
        {

            return SqlHelper.ExecuteWrite((con) => con.Insert(new Account() { GUID = guid, CreateTime = DateTime.Now, LastTime = DateTime.Now }));
        }

        public Comm.PageModel<T> Paging<T>(string TableName, int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            throw new NotImplementedException();
        }
    }
}
