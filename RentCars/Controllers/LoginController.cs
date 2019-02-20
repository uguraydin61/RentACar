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
    public class LoginController : Controller
    {
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
                            a.UserName
                        }).FirstOrDefault();

                if (x != null)
                {
                    Session["Kullanici"] =x.UserName;

                }
                 
                return RedirectToAction("Index", "Home");

            }
           
            return View();
        }
    }
}