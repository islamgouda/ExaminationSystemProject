using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemProject.Models
{
    public class Student_Exam
    {
       
        public int Id { get; set; }
       [Required]
        //[Key]
       // [Column(Order = 0)]
        [ForeignKey("Exam")]
        public int ExamID { get; set; }

      //  [Required]
      //  [Key]
      //  [Column(Order = 1)]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public int StudentDegree { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Exam? Exam { get; set; }
    }
}
