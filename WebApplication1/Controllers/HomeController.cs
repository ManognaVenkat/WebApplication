using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "my contact page.";

            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult example()
        {
            return View("Contact");
        }
        public ActionResult qa()
        {
            return View();
            
        }
        public ActionResult edit( int id,string name)
        {
            return Content("employee id is:"+ id+"employee name is:" + name);
           
        }
    }
}