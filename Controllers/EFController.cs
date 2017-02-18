using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    // [Authorize]
    public class EFController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {
            MyDbContext ctx = new MyDbContext();
            return View(ctx.Courses.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            EFCourse c = new EFCourse();
            return View(c);
        }

        [HttpPost]
        public ActionResult Add(EFCourse course)
        {
            try
            {
                MyDbContext ctx = new MyDbContext();
                ctx.Courses.Add(course);
                ctx.SaveChanges();
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
            MyDbContext ctx = new MyDbContext();
            var course = ctx.Courses.Find(id);
            if (course == null)
                ViewBag.Message = "Sorry! Course Not Found!";
            else
            {
                ctx.Courses.Remove(course);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            MyDbContext ctx = new MyDbContext();
            var course = ctx.Courses.Find(id);
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
        public ActionResult Edit(EFCourse course)
        {
            MyDbContext ctx = new MyDbContext();
            var dbcourse = ctx.Courses.Find(course.Code);
            if (dbcourse == null)
                TempData["message"] = "Sorry! Course Not Found!";
            else
            {
                dbcourse.Title = course.Title;
                dbcourse.Duration = course.Duration;
                dbcourse.Fee = course.Fee;
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}