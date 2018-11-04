using AdminModel;
using IDAL;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenuBLL : IMenuBLL
    {
        public IMenuDAL MenuDAL;
        public MenuBLL(IMenuDAL menudal)
        {
            MenuDAL = menudal;
        }
        public List<Menu> GetMenus()
        {
            return MenuDAL.GetMenus();
        }
        public int AddMenu(Menu menu)
        {
            return MenuDAL.AddMenu(menu);
        }
    }
}
