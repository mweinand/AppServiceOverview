using System;
using System.Web.Mvc;

namespace AppServiceOverview.Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 0, Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index()
        {
            #region Oops
            // throw new Exception("Oops"); 
            #endregion

            ViewBag.ComputerName = Environment.MachineName;
            return View();
        }
    }
}