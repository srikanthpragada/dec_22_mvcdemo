using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class User
    {
        [EmailAddress (ErrorMessage ="Invalid Email Address")]
        [Required (ErrorMessage ="Missing Email Address")]
        public String Email { get; set; }

        [Required]
        [StringLength(10,MinimumLength = 4, ErrorMessage = "Password Must Be 4 to 10 Chars")]
        public String Password { get; set; }
    }
}