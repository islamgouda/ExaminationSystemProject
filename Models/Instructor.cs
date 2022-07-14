using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemProject.Models
{
    public class Instructor
    {
        public int ID { get; set; }


        [Display(Name = "Instructor Name")]
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 letter")]
        [MinLength(3, ErrorMessage = "Name must be greater than 2 letter")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual List<Exam>? Exams { get; set; }

        public virtual List<Course>?Courses { get; set; }
    }
}
