﻿using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class CarsController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Cars
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.FilterElemans = TempData["Filter"];
            return View(_uw.CarRep.HepsiniGetir());
        }

        public ActionResult CarDetail(int? id)
        {

            if (id.HasValue)
            {
                Car CarDetail = _uw.CarRep.BirTaneGetir(id.Value);
                return View(CarDetail);
            }
            else
                return RedirectToAction("Index", "Cars");

           

        }
        [HttpPost]

        public ActionResult CarDetail(Rezervation rez)
        {
            if (ModelState.IsValid)
            {
                if (rez != null)
                {
                    _uw.RezervationRep.Ekle(rez);
                    return RedirectToAction("Index","Cars");
                }
             
               

            }
            return View();
            
        }
    }
}