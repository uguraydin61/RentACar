using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Areas.Panel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Panel/Login
        RentContext db = new RentContext();
        public ActionResult Index(string Username,string Password)
        {

            if (!(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))){

                if (Username == "Veysi" && Password == "123")
                {
                    Session["Giris"] = "Tamam";
                    return RedirectToAction("Index", "Car");
                }
            }
           

            return View();
        }
    }
}