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
    public class CarDetailController : Controller
    {
        // GET: Panel/CarDetail
        UnitOfWork _uw = new UnitOfWork();


       RentContext db = new RentContext();
        public ActionResult Index(int id)
        {



           
                return View(db.CarDetail.ToList());
            
           
          
           
         
        }
        public ActionResult Sil(int? id)
        {
            if (id.HasValue)
            {

            }
           

            return RedirectToAction("Index");
        }

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
        public ActionResult Yeni(int? id)
        {


           

            return View();
        }

        [HttpPost]
        public ActionResult Yeni(CarDetail yenidetay,int? id)
        { 
            if (ModelState.IsValid)
            {
                _uw.CarDetailRep.ArabaylaEkle(yenidetay,id.Value);
                return RedirectToAction("Index");
            }
            ViewBag.Arabalar = _uw.CarRep.HepsiniGetir();
            return View(yenidetay);
        }
        //Marka/Duzenle/5
        //{controller}/{action}/{id}

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            if (db.CarDetail.Any(x => x.Id == id))
            {            
                return View(_uw.CarDetailRep.BirTaneGetir(id));
            }
            else
            {
                return RedirectToAction("Yeni","CarDetail",new {id});
            }
         
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
