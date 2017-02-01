using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {
            MyDataContext dc = new MyDataContext();
            return View(dc.Courses);
        }


        [HttpGet]
        public ActionResult Add()
        {
            LinqCourse c = new LinqCourse();
            return View(c);
        }

        [HttpPost]
        public ActionResult Add(LinqCourse course)
        {
            try
            {
                MyDataContext dc = new MyDataContext();
                dc.Courses.InsertOnSubmit(course);
                dc.SubmitChanges();
                ViewBag.Message = "Course has been added successfully!";
            }
            catch (Exception ex)
            {
                HttpContext.Trace.Write("Error : " + ex.Message);
                ViewBag.Message = "Sorry! Could not add course!";
            }

            return View(course);
        }

        public ActionResult Delete(String id)
        {
            MyDataContext dc = new MyDataContext();
            var course = (from c in dc.Courses
                          where c.Code == id
                          select c).SingleOrDefault();

            if (course == null)
                ViewBag.Message = "Sorry! Course Not Found!";
            else
            {
                dc.Courses.DeleteOnSubmit(course);
                dc.SubmitChanges();
            }

            return RedirectToAction("Index");
        }

    }
}