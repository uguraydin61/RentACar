using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Pricing()
        {
            return View();
        }
        public ActionResult Driver()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult HelpDesk()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
    }
}