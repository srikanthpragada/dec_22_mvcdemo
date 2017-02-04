using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    // [Authorize]
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

        [HttpGet]
        public ActionResult Edit(String id)
        {
            MyDataContext dc = new MyDataContext();
            var course = (from c in dc.Courses
                          where c.Code == id
                          select c).SingleOrDefault();

            if (course == null)
            {
                return Content("Sorry! Course Code Not Found!");
            }
            else
            {
                return View(course);
            }
        }

        [HttpPost]
        public ActionResult Edit(LinqCourse course)
        {
            MyDataContext dc = new MyDataContext();
            var dbcourse = (from c in dc.Courses
                          where c.Code == course.Code
                          select c).SingleOrDefault();

            if (dbcourse == null)
            {
                return Content("Sorry! Course Not Found!");
            }
            else
            {
                dbcourse.Title = course.Title;
                dbcourse.Duration = course.Duration;
                dbcourse.Fee = course.Fee;
                dc.SubmitChanges();  // update 
                TempData["message"] = "";
            }

            return RedirectToAction("Index");
        }

        public string ValidateCode(String id)
        {
            MyDataContext dc = new MyDataContext();
            var course = (from c in dc.Courses
                          where c.Code == id
                          select c).SingleOrDefault();

            if (course == null)
                return "";
            else
                return "Code is existing!";
        }

        [HttpGet]
        public ActionResult SelectCourse()
        {
            MyDataContext dc = new MyDataContext();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(LinqCourse c in  dc.Courses)
            {
                items.Add(new SelectListItem { Text = c.Title, Value = c.Code });

            }
            return View(items);
        }

        [HttpPost]
        public ActionResult SelectCourse(String course)
        {
            MyDataContext dc = new MyDataContext();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (LinqCourse c in dc.Courses)
            {
                items.Add(new SelectListItem { Text = c.Title, Value = c.Code });

            }
            ViewBag.Message = "You Selected Course : " + course;
            return View(items);
        }


    }
}