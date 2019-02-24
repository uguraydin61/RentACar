using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class PackageController : Controller
    {
        // GET: Panel/Package
        UnitOfWork _uw = new UnitOfWork();



        // GET: Marka
        public ActionResult Index(int? sil)
        {
            if (Session["Giris"] == null)
            {

                return RedirectToAction("Index", "Login");

            }

            if (sil.HasValue)
            {
                _uw.PackageRep.Sil(sil.Value);

            }
            return View(_uw.PackageRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.PackageRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Package gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.PackageRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            ViewBag.Gruplar = _uw.PackageRep.HepsiniGetir();
            return View(_uw.PackageRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(Package yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.PackageRep.Guncelle(yeni);
                return RedirectToAction("Index");
            }

            return View(yeni);
        }
    }
}
