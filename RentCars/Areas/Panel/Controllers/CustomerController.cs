﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Panel/Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}