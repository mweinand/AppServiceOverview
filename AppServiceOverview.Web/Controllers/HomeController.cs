using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppServiceOverview.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 0, Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index()
        {
            ViewBag.ComputerName = Environment.MachineName;
            return View();
        }
    }
}