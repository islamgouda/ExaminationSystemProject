using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemProject.ViewModel
{
    public class StudentVM
    {
        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
    }
}
