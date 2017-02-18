
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcdemo.Models
{
    [Table("courses")]
    public class EFCourse
    {
        [Key]
        public string Code { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int Fee { get; set; }
    }
}