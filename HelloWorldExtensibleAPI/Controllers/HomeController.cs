using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldExtensibleAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return RedirectToAction("Hello");

            //return View();
        }

        public ActionResult Hello()
        {
            ViewBag.Title = "Extensible Hello World";

            return View();
        }
    }
}
