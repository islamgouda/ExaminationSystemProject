using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExaminationSystemProject.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(15, 50)]
        public int MinDegree { get; set; }

        [Required]
        [Range(25, 100)]

        public int? MaxDegree { get; set; }

        public string? Description { get; set; }

      //  [ValidateNever]
      //  public string? ImageFileName { get; set; }


      //  [NotMapped]
      //  public IFormFile? ImageFile { get; set; }


        [ForeignKey("Instructor")]

        public int? InstructorID { get; set; }

        public virtual Instructor? Instructor { get; set; }

    }
}
