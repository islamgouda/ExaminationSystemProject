using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                return RedirectToAction("SelectQuestions");
            }
            return View("New", e);
        }
        public IActionResult SelectQuestions(int id)
        {
            Exam x=exam.GetById(id);
            ViewData["Questions"] = context.Questionpools.Where(c => c.CourseId == x.CourseId).ToList();
            return View(x);
        }


        ///////
        public IActionResult createexam()
        {
            ViewData["CourseList"] = context.Courses.ToList();
            return View();
        }
      public IActionResult createnew(int courseID,Exam e)
        {
           int exID= exam.insertAndGetId(e);
           List<Questionpool> questionpools = context.Questionpools.Where(c => c.CourseId == courseID).ToList();
            ExViewModel ex = new ExViewModel();
            ex.questionpools = new List<Questionpool>();
            ex.ExID = exID;
            ex.questionpools = questionpools;
            return View(ex);
        }
        public IActionResult chooseqst(int id, int[] choose=null)
        {
            Exam ex=exam.GetById(id);
          //  List<Questionpool> questionpools = context.Questionpools.Where(c => c.CourseId == ex.CourseId).ToList();
            //return Content(choose[0].ToString());
          //  int co = 0;
            foreach (int questID in choose)
           {
            // if (choose[co++])
              //  {
                    ExamQuestions examQuestions = new ExamQuestions();
                examQuestions.QuestID = questID;
                    examQuestions.ExamID = id;
                    context.ExamQuestions.Add(examQuestions);
                    context.SaveChanges();
                   // co++;
               // }
           }
            
            return Content("saved");

        }

    }
}
