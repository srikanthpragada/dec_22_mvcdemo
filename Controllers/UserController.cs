using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            User u = new User { Email = "admin@abc.com" };
            return View(u);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            if (user.Email == "admin@abc.com" && user.Password == "1234")
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["user"] = user.Email;
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.Message = "Invalid Login. Try Again!";
                return View(user);
            }
        }

        [Authorize]
        public ActionResult Home()
        {
            //ViewBag.User = Session["user"];
            ViewBag.User = User.Identity.Name;
            return View();
        }


    }
}