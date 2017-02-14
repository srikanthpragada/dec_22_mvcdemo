using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class CoursesController : ApiController
    {
        [HttpGet]
        public IEnumerable<LinqCourse> GetCourses()
        {
            MyDataContext dc = new MyDataContext();
            return dc.Courses;
        }

        [HttpGet]
        public IHttpActionResult GetCourse(String id)
        {
            MyDataContext dc = new MyDataContext();
            var course = dc.Courses.Where(c => c.Code == id).SingleOrDefault();
            if (course != null)
                return Ok(course);
            else
                return NotFound();
        }

        [HttpPost]
        public void AddCourse(LinqCourse course)
        {
            try
            {
                MyDataContext dc = new MyDataContext();
                dc.Courses.InsertOnSubmit(course);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = HttpStatusCode.InternalServerError;
                msg.ReasonPhrase = "Error while adding course -> " + ex.Message;
                throw new HttpResponseException(msg);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCourse(String id)
        {
            MyDataContext dc = new MyDataContext();
            var course = dc.Courses.Where(c => c.Code == id).SingleOrDefault();
            if (course != null)
            {
                dc.Courses.DeleteOnSubmit(course);
                dc.SubmitChanges();
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut]
        public IHttpActionResult UpdateCourse(String id, LinqCourse course)
        {
            MyDataContext dc = new MyDataContext();
            var dbcourse = dc.Courses.Where(c => c.Code == id).SingleOrDefault();
            if (dbcourse != null)
            {
                try
                {
                    dbcourse.Title = course.Title;
                    dbcourse.Duration = course.Duration;
                    dbcourse.Fee = course.Fee;
                    dc.SubmitChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Trace.Write("Error : " + ex.Message);
                    return this.BadRequest();
                }
            }
            else
                return NotFound();
        }
    }
}
