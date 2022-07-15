using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    [Authorize(Roles =("Admin"))]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> rolemanager;

        public RolesController(RoleManager<IdentityRole> _roleManager)
        {
            this.rolemanager = _roleManager;
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel newrole)
        {
            if(ModelState.IsValid)
            {
               IdentityRole role=new IdentityRole();
                role.Name = newrole.RoleName;
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
            
            return View(newrole);
        }
    }
}
