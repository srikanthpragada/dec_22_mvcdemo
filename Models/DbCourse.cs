using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class DbCourse
    {
        [Required]
        public String Code { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public int Duration { get; set; }

        public int Fee { get; set; }
    }
}