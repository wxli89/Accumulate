using AdminModel;
using IBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoyatWeb.Controllers
{
    public class JoyController : SystemRegistController
    {
        private IJokeBLL JokeBLL;
        private IIsReadBLL IsReadBLL;
        public JoyController(IJokeBLL jokeBLL, IAccountBLL accountBLL, IIsReadBLL isReadBLL)
            : base(accountBLL)
        {
            JokeBLL = jokeBLL;
            AccountBLL = accountBLL;
            IsReadBLL = isReadBLL;
        }
        [HttpPost]
        public ActionResult More(int pageIndex = 2)
        {
            string guid = "";
            string sqlwhere = "";
            HttpCookie cookie = Request.Cookies["GUID"];
            if (cookie != null)
            {
                guid = cookie.Values["ID"];
                sqlwhere = "AND ID NOT IN (SELECT JokeID FROM IsRead WHERE GUID = '" + guid + "')";
            }
            else { guid = MakeGuid; }
            var list = JokeBLL.Paging<Joke>("joke", OrderBy: "ZAN DESC", PageSize: 10, PageIndex: pageIndex, Where: sqlwhere);
            List<IsRead> reads = new List<IsRead>();
            foreach (var item in list.Data)
            {
                reads.Add(new IsRead()
                {
                    JokeID = item.ID,
                    GUID = guid
                });
            }
            IsReadBLL.AddIsRead(reads);
            return Json(list.Data);
        }

        public int Up_down(int id, int op)
        {
            int result = -1;
            if (op == 1)
                result = JokeBLL.Zan(id);
            else if (op == 0)
                result = JokeBLL.Cai(id);
            return result;
        }

        public ActionResult Index()
        {
            string guid = "";
            string sqlwhere = "";
            HttpCookie cookie = Request.Cookies["GUID"];
            if (cookie != null)
            {
                guid = cookie.Values["ID"];
                sqlwhere = "AND ID NOT IN (SELECT JokeID FROM IsRead WHERE GUID = '" + guid + "')";
            }
            else { guid = MakeGuid; }
            var list = JokeBLL.Paging<Joke>("joke", OrderBy: "ZAN DESC", PageSize: 10, Where: sqlwhere);
            List<IsRead> reads = new List<IsRead>();
            foreach (var item in list.Data)
            {
                reads.Add(new IsRead()
                {
                    JokeID = item.ID,
                    GUID = guid
                });
            }
            IsReadBLL.AddIsRead(reads);
            return View(list);
        }

    }
}
