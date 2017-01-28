using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CourseController : Controller
    {

        public ActionResult List()
        {
            List<Course> courses = new List<Course>
            {
                new Course { Name ="ASP.NET MVC", Duration=20, Fee = 2000 },
                new Course { Name ="Java SE", Duration=40, Fee = 3500 },
                new Course { Name ="Oracle Database <i>12c</i>", Duration=40, Fee = 3500 }
            };
            return View(courses);
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
    }
}