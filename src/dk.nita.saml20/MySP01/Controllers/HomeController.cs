using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySP01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }


        public ActionResult AuthenticatedOnly()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Message = "Hvis du når hertil er du blevet authenticated";

            return View();
        }

        ///
        public ActionResult Login()
        {
            return Redirect("/login.ashx?ReturnUrl=/");
        }

        public ActionResult Logout()
        {
            return Redirect("/logout.ashx");
        }

    }
}