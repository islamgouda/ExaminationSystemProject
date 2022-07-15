using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemProject.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RemmberMe { get; set; }
    
        
    }
}
