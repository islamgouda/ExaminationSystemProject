using Microsoft.AspNetCore.Identity;

namespace ExaminationSystemProject.Models
{
    public class ApplicationUser:IdentityUser
    {

        public int UserId { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        
        


    }
}
