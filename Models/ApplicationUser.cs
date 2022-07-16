using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        
        


    }
}
