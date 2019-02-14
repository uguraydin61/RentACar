using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class BlogController : Controller
    {
        // GET: Panel/Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}