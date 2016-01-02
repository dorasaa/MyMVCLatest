using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyMVCLatest.Models;

namespace MyMVCLatest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            ViewBag.GenericMessage = "AreEqual ?" + GenericsTest<string>.AreEqual("B", "B");

            customer c1 = new customer();
            c1.fname="Satish";
            c1.lname = "Doranahalli";

            ViewBag.Customer = "Dear " + c1.ToString() ;


            return View();
        }

         

        public ActionResult Countries()
        {
            ViewData["Countries"] = new List<string>()
             {
             "UK",
             "India",
             "USA",
             "Ireland",
             "Scotland",

             };



            return View();


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
