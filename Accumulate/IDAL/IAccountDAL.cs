using Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAccountDAL : IPaging
    {
         int SystemRegist(string GUID);
    }
}
