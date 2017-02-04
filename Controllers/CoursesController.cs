using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class CoursesController : ApiController
    {
        List<Course> courses = new List<Course>
        {
            new Course { Name = "Microsoft.Net", Duration = 55, Fee = 5500 },
            new Course { Name = "Java SE 8.0", Duration = 40, Fee = 3500 },
            new Course { Name = "Java EE 7.0", Duration = 50, Fee = 4000 }
        };

        public List<Course> GetCourses()
        {
            return courses;
        }

        public Course GetCourse(int id)
        {
            return courses[id-1];
        }
    }
}
