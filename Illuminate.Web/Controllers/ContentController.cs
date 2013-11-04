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

        public ActionResult Create()
        {
            return View();
        }

    }
}
