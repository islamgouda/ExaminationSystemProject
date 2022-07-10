using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExaminationSystemProject.Models
{
    public class StudentCourse
    {
        [Key]
      public int ID { get; set; }
       // [Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentID { get; set; }


       // [Key]
       // [Column(Order = 1)]
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}
