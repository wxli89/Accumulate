using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IMenuDAL
    {
        List<Menu> GetMenus();
        int AddMenu(Menu menu);
    }
}
