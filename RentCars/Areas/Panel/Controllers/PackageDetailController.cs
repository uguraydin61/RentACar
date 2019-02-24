using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class PackageDetailController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        RentContext db = new RentContext();
        // GET: Panel/PackageDetail
        public ActionResult Index()
        {
            if (Session["Giris"] == null)
            {

                return RedirectToAction("Index", "Login");

            }
            return View(_uw.PackageDetailRep.HepsiniGetir());
        }

        public ActionResult Yeni()
        {
            ViewBag.Gruplar = _uw.PackageRep.HepsiniGetir();
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(PackageDetail gelen)
        {
            if (ModelState.IsValid)
            {
                _uw.PackageDetailRep.Ekle(gelen);
                return RedirectToAction("Index");
            }
            return View(gelen);
        }
        public ActionResult Sil(int? id)
        {
            if (id.HasValue)
            {
                _uw.PackageDetailRep.Sil(id.Value);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            if (db.PackageDetail.Any(x => x.Id == id))
            {
                return View(_uw.CarDetailRep.BirTaneGetir(id));
            }
            else
            {
                return RedirectToAction("Yeni", "PackageDetail", new { id });
            }

        }

        [HttpPost]
        public ActionResult Duzenle(CarDetail yeni)
        {
            if (ModelState.IsValid)
            {
                _uw.CarDetailRep.Guncelle(yeni);
                return RedirectToAction("Index", "Car");
            }

            return View(yeni);
        }

    }
}