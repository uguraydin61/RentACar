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
            ViewBag.Markalar = _uw.CarBrandRep.HepsiniGetir();
            ViewBag.Vendors = _uw.VendorRep.HepsiniGetir();

            return View();
        }
        //model binding: uygun parametreler gelirse modele çevirme
        [HttpPost]
        public ActionResult Yeni(Car yeniurun, int MarkaId,int VendorId, HttpPostedFileBase CarImage)
        {
            if (ModelState.IsValid)
            {
                _uw.CarRep.MarkaylaEkle(yeniurun, MarkaId, VendorId);
                var path = Server.MapPath("/Uploads/");
                CarImage.SaveAs(path + yeniurun.Id + ".jpg");

               
                return RedirectToAction("Index", "Car");
                //Action: Controller
            }
            ViewBag.Markalar = _uw.CarBrandRep.HepsiniGetir();
            ViewBag.Vendors = _uw.VendorRep.HepsiniGetir();
          
            return View(yeniurun);

        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            
            ViewBag.Markalar = _uw.CarBrandRep.HepsiniGetir();
            ViewBag.Vendors = _uw.VendorRep.HepsiniGetir();

            return View(_uw.CarRep.BirTaneGetir(id));
        }

        [HttpPost]
        
        public ActionResult Duzenle(Car cars,HttpPostedFileBase CarImage)
        {
            if (ModelState.IsValid)
            {
              
                if (CarImage != null)
                {
                   
                    var path = Server.MapPath("/Uploads/");
                    CarImage.SaveAs(path + cars.Id + ".jpg");
                }
                _uw.CarRep.Guncelle(cars);
                return RedirectToAction("Index");
            }
           
            ViewBag.Markalar = _uw.CarBrandRep.HepsiniGetir();
            ViewBag.Vendors = _uw.VendorRep.HepsiniGetir();
            return View(cars);
        }

    }
}
