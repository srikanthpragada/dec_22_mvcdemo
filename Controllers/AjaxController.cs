using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public String Today()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String pattern)
        {
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            List<DbCourse> courses = new List<DbCourse>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from courses where title like @pattern", con);
                cmd.Parameters.AddWithValue("@pattern", "%" + pattern + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DbCourse c = new DbCourse
                    {
                        Code = dr["code"].ToString(),
                        Title = dr["title"].ToString(),
                        Duration = Int32.Parse(dr["duration"].ToString()),
                        Fee = Int32.Parse(dr["fee"].ToString()),
                    };

                    courses.Add(c);
                }
                return  PartialView("SearchResult",courses);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return  PartialView("SearchResult", courses);
            }
        }

    }
}