using AdminModel;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyatWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private IJokeBLL JokeBLL;
        public HomeController(IJokeBLL jokebll)
        {
            JokeBLL = jokebll;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult game()
        {
            return View();
        }
        
    }
}
