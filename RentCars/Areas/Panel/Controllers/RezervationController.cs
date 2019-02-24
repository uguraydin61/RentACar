using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class RezervationController : Controller
    {
        // GET: Panel/Rezervation
        public ActionResult Index()
        {
            if (Session["Giris"] == null)
            {

                return RedirectToAction("Index", "Login");

            }
            return View();
        }
    }
}