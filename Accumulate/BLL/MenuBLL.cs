using AdminModel;
using IDAL;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comm;

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
        public int DelMenu(IList<int> ids)
        {
            return MenuDAL.DelMenu(ids);
        }
        public int UpdateMenu(Menu menu)
        {
            return MenuDAL.UpdateMenu(menu);
        }

        public PageModel<T> Paging<T>(string TableName, int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            return MenuDAL.Paging<T>(TableName, PageSize, PageIndex, OrderBy, Where);
        }
    }
}
