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
            if (Session["Giris"] == null)
            {

                return RedirectToAction("Index", "Login");

            }
            return View();
        }
    }
}