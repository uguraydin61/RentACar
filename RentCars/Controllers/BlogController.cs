using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class BlogController : Controller
    {
        // GET: Controller
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
    }
}