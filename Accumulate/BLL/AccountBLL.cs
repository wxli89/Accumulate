using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL : IAccountBLL
    {
        public IAccountDAL AccountDAL;
        public AccountBLL(IAccountDAL accountDAL)
        {
            AccountDAL = accountDAL;
        }
        public int SystemRegist(string guid)
        {
            return AccountDAL.SystemRegist(guid);
        }
    }
}
