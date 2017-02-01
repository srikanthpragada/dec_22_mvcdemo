using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    class MyDataContext : DataContext
    {
        public MyDataContext() :
            base(Database.ConnectionString)
        {
        }
        public Table<LinqCourse> Courses
        {
            get
            {
                return GetTable<LinqCourse>();
            }
        }
    }
}