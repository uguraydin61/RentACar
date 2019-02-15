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
        public ActionResult Index(string Username,string Password)
        {
            FilterViewModel _vw = new FilterViewModel();
            _vw.Vendors = db.Vendor.ToList();
            _vw.CarBrands = db.CarBrand.ToList();
          var price= Convert.ToDecimal(Request.Form["MaxPrice"]);
            var brand = Convert.ToInt32(Request.Form["brandID"]);
            var vendor = Convert.ToInt32(Request.Form["VendorId"]);
          
          
            var FilterElemans = db.Car.Where(x => x.VendorId == vendor && x.BrandId == brand && x.Price <= price).ToList();
         
            if (FilterElemans.Count() > 0)
            {
               TempData["Filter"] = FilterElemans.ToList();
                return RedirectToAction("Cars","Cars");

            }
       
          
       


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