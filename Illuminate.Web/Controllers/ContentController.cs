using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Illuminate.Web.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/

        public ActionResult CreateContent(string userid)
        {
            ViewBag.LoggedInUser = userid;
            return View();
        }

        //
        // GET: /NewsFeed/

        public ActionResult NewsFeed(string userid)
        {
            ViewBag.LoggedInUser = userid;
            return View();
        }

    }
}
