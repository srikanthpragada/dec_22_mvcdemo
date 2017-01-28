using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class DbCourseController : Controller
    {
        // GET: DbCourse
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            List<DbCourse> courses = new List<DbCourse>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from courses", con);
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

                return View(courses);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return View(courses);
            }
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from courses where code = @code", con);
                cmd.Parameters.AddWithValue("@code", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DbCourse c = new DbCourse
                    {
                        Code = dr["code"].ToString(),
                        Title = dr["title"].ToString(),
                        Duration = Int32.Parse(dr["duration"].ToString()),
                        Fee = Int32.Parse(dr["fee"].ToString()),
                    };
                    return View(c);
                }
                else
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error : " + ex.Message;
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult Edit(DbCourse course)
        {
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update courses set title= @title, duration = @duration, fee = @fee  where code = @code", con);
                cmd.Parameters.AddWithValue("@code", course.Code);
                cmd.Parameters.AddWithValue("@title", course.Title);
                cmd.Parameters.AddWithValue("@duration", course.Duration);
                cmd.Parameters.AddWithValue("@fee", course.Fee);
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return View(course);
            }
             
        }




        public ActionResult Delete(String id)
        {
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from courses where code = @code", con);
                cmd.Parameters.AddWithValue("@code",id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error : " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            DbCourse c = new DbCourse { };
            return View(c);
        }

        [HttpPost]
        public ActionResult Add(DbCourse course)
        {
            if (!ModelState.IsValid)
            {
               return View(course);
            }

            SqlConnection con = new SqlConnection(Database.ConnectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into courses values(@code,@title,@duration,@fee)", con);
                cmd.Parameters.AddWithValue("@code", course.Code);
                cmd.Parameters.AddWithValue("@title", course.Title);
                cmd.Parameters.AddWithValue("@duration", course.Duration);
                cmd.Parameters.AddWithValue("@fee", course.Fee);
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return View(course);
            }
            
        }


    }
}