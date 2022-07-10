using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExaminationSystemProject.Models
{
    public class Questionpool
    {
        public int ID { get;set; }
        public string Type { get;set; }
        public string Questiontxt { get;set; }
        public string Correctanswer { get;set; }
        public int Degree { get; set; }
        [ForeignKey("course")]
        public int CourseId { get; set; }
        public Course? course { get; set; }
    }
}
