using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    // [OutputCache(Duration = 60 ,  VaryByParam = "*")]
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

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            ViewBag.Message = "Uploaded : " + photo.FileName;
            // save photo into photos folder in web application
            photo.SaveAs(Request.MapPath("~/photos/" + photo.FileName));
            return View();
        }

        public ActionResult ListPhotos()
        {
            DirectoryInfo dir = new DirectoryInfo(Request.MapPath("~/photos"));
            FileInfo[] files = dir.GetFiles();
            List<String> filenames = new List<String>();

            foreach (FileInfo finfo in files)
                filenames.Add(finfo.Name);

            ViewBag.Message = dir.FullName;
            return View(filenames);
        }

        public ActionResult Today()
        {
            ViewBag.Message = DateTime.Now.ToString(); 
            return View();
        }
    }
}