using ExaminationSystem.Reprository;
using ExaminationSystemProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    public class RegisterCourseController : Controller
    {
        IRegisterRepository registerRepository;
        ICourseReprository courseReprository;
        public RegisterCourseController(IRegisterRepository registerRepository,ICourseReprository courseReprository)
        {
            this.registerRepository = registerRepository;
            this.courseReprository = courseReprository;
        }



        public IActionResult CourseRegister()
        {
            ViewBag.Courses=

            return View();
        }
    }
}
