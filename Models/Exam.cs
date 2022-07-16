using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemProject.Models
{
    public class Exam
    {
        [Key]
        public int Id { set; get; }

        //
        [ForeignKey("Course")]
        public int CourseId { set; get; }

        //
        [ForeignKey("Instructor")]
        public int InstructorId { set; get; }

        [Display(Name ="Start")]
        [DataType(DataType.DateTime)]
        public DateTime Start { set; get; }
        [Display(Name = "End")]
        [DataType(DataType.DateTime)]
        public DateTime End { set; get; }
        public int degree { set; get; }
        public List<ExamQuestions> ExamQuestions { set; get; }
        public Instructor Instructor { set; get; }
        public Course Course { set; get; }

    }
}
