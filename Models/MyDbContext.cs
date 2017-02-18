using System.Data.Entity;

namespace mvcdemo.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() :
             base(mvcdemo.Models.Database.ConnectionString)
        { }

        public DbSet<EFCourse> Courses { get;set;}
    }
}