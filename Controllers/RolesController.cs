using ExaminationSystemProject.Models;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> rolemanager;

        public RolesController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            this.rolemanager = _roleManager;
            this.userManager = _userManager;
        }
        [HttpGet]
        public IActionResult New()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(string RoleName)
        {
            if(ModelState.IsValid)
            {
               IdentityRole role=new IdentityRole();
                role.Name = RoleName;
               IdentityResult result=await rolemanager.CreateAsync(role);
               if(result.Succeeded)
                {
                    return View(new RoleViewModel());
                }
               foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
                        return View(RoleName);
        }
    }
}
