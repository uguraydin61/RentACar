using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class CarController : Controller
    {
        // GET: Panel/Car
        UnitOfWork _uw = new UnitOfWork();

        // GET: Marka
        public ActionResult Index(int? sil)
        {
            if (sil.HasValue)
            {
                _uw.CarRep.Sil(sil.Value);
            }
            return View(_uw.CarRep.HepsiniGetir());

        }
        [HttpGet]
        public ActionResult Yeni()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Yeni(Car m)
        {
            if (ModelState.IsValid)
            {
                _uw.CarRep.Ekle(m);
                return RedirectToAction("Index");
            }

            return View(m);

        }
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.CarRep.HepsiniGetir();
            return View(_uw.CarRep .BirTaneGetir(id));

        }
        [HttpPost]
        public ActionResult Duzenle(Car yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.CarRep.Guncelle(yeni);
                return RedirectToAction("Index");

            }
            ViewBag.Gruplar = _uw.CarRep.HepsiniGetir();
            return View(yeni);

        }
    }
}