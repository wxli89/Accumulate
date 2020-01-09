using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyatAdmin.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Index(int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            return View();
        }

    }
}
