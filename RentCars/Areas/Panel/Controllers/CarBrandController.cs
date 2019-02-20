using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class CarBrandController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();



        // GET: Marka
        public ActionResult Index(int? sil)
        {

            if (sil.HasValue)
            {
                _uw.CarBrandRep.Sil(sil.Value);

            }
            return View(_uw.CarBrandRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.CarBrandRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(CarBrand gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.CarBrandRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.CarBrandRep.HepsiniGetir();
            return View(_uw.CarBrandRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(CarBrand yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.CarBrandRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }

            return View(yeni);
        }
    }
}