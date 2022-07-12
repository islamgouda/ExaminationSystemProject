using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemProject.Controllers
{
    public class ExamController : Controller
    {
        private IExam exam;
        Context context=new Context();
        public ExamController(IExam _exam)
        {
            exam = _exam;
        }
        public IActionResult Index()
        {
            List<Exam> Result= exam.GetAll();
            return View(Result);
        }
       
        public IActionResult ADD()
        {
            ViewData["CourseList"]=context.Courses.ToList();
            return View(new Exam());
        }
       

        [HttpPost]
        public IActionResult SaveNew(Exam e)
        {
            if (e.CourseId != null)
            {
                exam.insert(e);
                return RedirectToAction("Index");
            }
            return View("New", e);
        }

    }
}
