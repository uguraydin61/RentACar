using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class HomeController : Controller
    {
        RentContext db = new RentContext();
        public ActionResult Index()
        {
            FilterViewModel _vw = new FilterViewModel();
            _vw.Vendors = db.Vendor.ToList();
            _vw.CarBrands = db.CarBrand.ToList();
            return View(_vw);
        }
        [HttpPost]
        public ActionResult Index(int brandId, int VendorId,decimal MaxPrice)
        {
            FilterViewModel _vw = new FilterViewModel();
            _vw.Vendors = db.Vendor.ToList();
            _vw.CarBrands = db.CarBrand.ToList();
          var price= Convert.ToDecimal(Request.Form["MaxPrice"]);
            var brand = Convert.ToInt32(Request.Form["brandID"]);
            var vendor = Convert.ToInt32(Request.Form["VendorId"]);
           

            //var a = from c in db.Car
            //        where c.VendorId == VendorId && c.BrandId == brandId && c.Price<=MaxPrice
          
            var FilterElemans = db.Car.Where(x => x.VendorId == vendor && x.BrandId == brand && x.Price <= price).ToList();
         
            if (FilterElemans.Count() > 0)
            {
               TempData["Filter"] = FilterElemans.ToList();
                return RedirectToAction("Cars","Cars");

            }
         


            TempData["Error"] = "Kriterlerinize uygun arabamız bulunamadı ... Tedarik için";
       




            return View(_vw);
        }
      
       
       
        public ActionResult _Funfact()
        {
            return View();
        }
        public ActionResult _ChooseCar()
        {
            return View();
        }
        public ActionResult _PricingArea()
        {
            return View();
        }
      

    }
}