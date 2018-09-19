using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyatAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuDAL menudal;
        public HomeController(IMenuDAL mdal)
        {
            menudal = mdal;
        }

        public ActionResult Index()
        {
            var list = menudal.GetMenus();
            return View(list);
        }

    }
}
