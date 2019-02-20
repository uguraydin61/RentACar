using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class CarDetailController : Controller
    {
        // GET: Panel/CarDetail
        UnitOfWork _uw = new UnitOfWork();



        // GET: Marka
        public ActionResult Index(int? sil)
        {

            if (sil.HasValue)
            {
                _uw.CarDetailRep.Sil(sil.Value);

            }
            return View(_uw.CarDetailRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.CarDetailRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(CarDetail gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.CarDetailRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.CarDetailRep.HepsiniGetir();
            return View(_uw.CarDetailRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(CarDetail yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.CarDetailRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }

            return View(yeni);
        }
    }
}
}