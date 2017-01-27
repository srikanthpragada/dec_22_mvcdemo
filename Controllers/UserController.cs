using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            User u = new User { Email = "admin@abc.com" };
            return View(u);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Email == "admin@abc.com" && user.Password == "123")
                return RedirectToAction("Home");
            else
            {
                ViewBag.Message = "Invalid Login. Try Again!";
                return View(user);
            }
        }
    }
}