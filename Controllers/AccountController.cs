using ExaminationSystemProject.Models;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> signInManager)
        {
            userManager = _userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel UserVM)
        {
            if (ModelState.IsValid==true)
            {
                //Check
            ApplicationUser userModel=  await  userManager.FindByNameAsync(UserVM.userName);
                if (userModel != null)
                {
                   bool found= await userManager.CheckPasswordAsync(userModel, UserVM.Password);
                    if(found)
                    {
                        await signInManager.SignInAsync(userModel, UserVM.RemmberMe);//ispresintent=true
                        return RedirectToAction("Index", "Course");
                    }
                }
                ModelState.AddModelError("", "User Name And Password invalid");

            }
            return View(UserVM);
        }





        [HttpGet]
        public IActionResult Registrasion()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Registrasion(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //CreateAccount
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                
                IdentityResult result= await userManager.CreateAsync(userModel,newUserVM.Password);

                if (result.Succeeded==true)
                {
                    //createCookie
                   await signInManager.SignInAsync(userModel, isPersistent: false);

                    return RedirectToAction("Index", "Course");
                }

                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }


            }

            return View(newUserVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}
