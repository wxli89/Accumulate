using AdminModel;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyatAdmin.Controllers
{
    public class SystemController : Controller
    {
        private IMenuBLL menubll;
        public SystemController(IMenuBLL menubll)
        {
            this.menubll = menubll;
        }
        public ActionResult Menu()
        {
            var list = menubll.Paging<Menu>("Menu", OrderBy: "Sort");
            return View(list);
        }
        [HttpPost]
        public ActionResult Menu(int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            var list = menubll.Paging<Menu>("Menu", PageSize, PageIndex, OrderBy, Where);
            return View(list);
        }
        public ActionResult AddMenu(Menu menu)
        {
            return Content(menubll.AddMenu(menu).ToString());
        }
        public ActionResult DelMenu(IList<int> ids)
        {
            return Json(menubll.DelMenu(ids));
        }
    }
}
