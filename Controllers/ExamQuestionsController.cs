using ExaminationSystemProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    public class ExamQuestionsController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestionsToExam(ExamQuestions eX)
        {
            
                context.ExamQuestions.Add(eX);
                int id = eX.ExamID;
                context.SaveChanges();
                return RedirectToAction("SelectQuestions", "Exam", new { id = id });
            
        }
    }
}
