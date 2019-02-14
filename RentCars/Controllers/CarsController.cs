using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Cars()
        {
            ViewBag.FilterElemans = TempData["Filter"];
            return View();
        }
    }
}