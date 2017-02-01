using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    [Table(Name = "courses")]
    public class LinqCourse
    {
        [Column(IsPrimaryKey = true)]
        public string Code { get; set; }

        [Column(Name = "Title")]
        public string Title { get; set; }

        [Column]
        public int Duration { get; set; }

        [Column]
        public int Fee { get; set; }
    }
}