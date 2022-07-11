using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    public class ExamController : Controller
    {
        private IExam exam;
        public ExamController(IExam _exam)
        {
            exam = _exam;
        }
        public IActionResult Index()
        {
           List<Exam> Result= exam.GetAll();
            return View(Result);
        }
        
    }
}
