using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comm;

namespace IBLL
{
    public interface IMenuBLL : IPaging
    {
        List<Menu> GetMenus();
        int AddMenu(Menu menu);
        int DelMenu(IList<int> ids);
        int UpdateMenu(Menu menu);
    }
}
