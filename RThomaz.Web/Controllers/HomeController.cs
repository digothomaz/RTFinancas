using System.Web.Mvc;
using RThomaz.Web.Common;

namespace RThomaz.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

        #endregion

        #region About

        [CustomAuthorize]
        public ActionResult About()
        {
            return View();
        }

        #endregion
    }
}
