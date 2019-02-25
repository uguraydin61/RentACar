using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class GirisController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();

        // GET: Login
        RentContext _db = new RentContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username,string Password)
        {
            var LoginCustomers = _db.Customer.Where(x => x.Password == Password && x.UserName == Username);
            if (LoginCustomers != null)
            {

                var x = (from a in LoginCustomers
                         select new
                         {
                             a.Id,
                            a.UserName
                        }).FirstOrDefault();

                if (x != null)
                {
                    Session["Kullanici"] =x.UserName;
                    Session["Exit"] = x.Id;
                    Session["Giris"] = x.Id;
                    return RedirectToAction("Index", "Home");


                }
                 
               

            }
           
            return View();
        }
        RentContext db = new RentContext();
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Paketler = db.Package.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            ViewBag.Paketler = db.Package.ToList();
            if (ModelState.IsValid)
            {
                if (customer != null)
                {
                    _uw.CustomerRep.Ekle(customer);
                    ViewBag.Message = "<script>alert('Başarıyla Eklendiniz ...')</script>";
                    return RedirectToAction("Index", "Home");
                }
                

            }

            return View();
        }
        [HttpGet]
        public ActionResult Exit(int id)
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");


        }
    }
}