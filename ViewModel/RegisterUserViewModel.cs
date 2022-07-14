using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemProject.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string confirmPassword { get; set; }
        public string Address { get; set; }
        public string Type  { get; set; }




    }
}
