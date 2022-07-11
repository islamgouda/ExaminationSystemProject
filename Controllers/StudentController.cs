using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
