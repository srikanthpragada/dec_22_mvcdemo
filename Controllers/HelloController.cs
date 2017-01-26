using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello    Hello/Index
        public ActionResult Index(string id = "Unknown")
        {
            Course c = new Course { Name = "AngularJS", Duration = 10, Fee = 2000 };
            return View(c);
        }

        public ActionResult Wish(string name)
        {
            ViewBag.Message = "Hello, " + name;
            return View();
        }
    }
}