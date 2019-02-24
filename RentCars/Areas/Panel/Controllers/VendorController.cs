using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class VendorController : Controller
    {


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
                _uw.VendorRep.Sil(sil.Value);

            }
            return View(_uw.VendorRep.HepsiniGetir());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Vendor v)
        {
            if (ModelState.IsValid)
            {
                _uw.VendorRep.Ekle(v);
                return RedirectToAction("Index");
            }
            return View(v);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            return View(_uw.VendorRep.BirTaneGetir(id));
        }

        [HttpPost]
        public ActionResult Duzenle(Vendor m)
        {
            if (ModelState.IsValid)
            {
                _uw.VendorRep.Guncelle(m);
                return RedirectToAction("Index");
            }

            return View(m);
        }
    }       
}