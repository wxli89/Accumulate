using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyatWeb.Controllers
{
    public class SystemRegistController : Controller
    {
        //
        // GET: /Base/
        public IAccountBLL AccountBLL;
        public SystemRegistController(IAccountBLL accountBLL)
        {
            AccountBLL = accountBLL;
        }
        public string MakeGuid = "";
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var GUID = filterContext.RequestContext.HttpContext.Request.Cookies["GUID"];
            if (GUID == null)
            {
                MakeGuid = Guid.NewGuid().ToString();
                if (AccountBLL.SystemRegist(MakeGuid) != 1)
                    return;
                HttpCookie cookie = new HttpCookie("GUID");
                cookie.Expires = DateTime.Now.AddDays(1000);
                cookie.Values.Add("ID", MakeGuid);
                Response.AppendCookie(cookie);
            }
        }
    }
}
