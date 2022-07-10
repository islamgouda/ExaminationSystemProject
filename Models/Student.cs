using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Course> Courses { set; get; }
    }
}
