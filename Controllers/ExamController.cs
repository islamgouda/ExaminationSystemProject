using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//createexam
//
namespace ExaminationSystemProject.Controllers
{

  //  [Authorize(Roles = ("Admin"))]
    public class ExamController : Controller
    {
        private IExam exam;
        Context context=new Context();
        public ExamController(IExam _exam)
        {
            exam = _exam;
        }
        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult Index()
        {
            List<Exam> Result= exam.GetAll();
            return View(Result);
        }

        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult ADD()
        {
            ViewData["CourseList"]=context.Courses.ToList();
            return View(new Exam());
        }


        [Authorize(Roles = ("Instructor,Admin"))]
        [HttpPost]
        public IActionResult SaveNew(Exam e)
        {
            if (e.CourseId != null)
            {
               int id= exam.insert(e);
                return RedirectToAction("SelectQuestions",new {id=id});
            }
            return View("New", e);
        }

        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult SelectQuestions(int id)
        {
            SelectQuestionViewModel Model = new SelectQuestionViewModel();
            Exam x=exam.GetById(id);
            ViewData["Questions"] = context.Questionpools.Where(c => c.CourseId == x.CourseId).ToList();
            return View(x);
        }


       // [Authorize(Roles = ("Admin"))]
        [Authorize(Roles = ("Instructor,Admin"))]
       // [Authorize(Roles = ("Instructor"))]
        public IActionResult createexam()
        {
            ViewData["CourseList"] = context.Courses.ToList();
            return View();
        }
      //  [Authorize(Roles = ("Instructor"))]
      //  [Authorize(Roles = ("Instructor"))]
        [Authorize(Roles =("Instructor,Admin"))]
        public IActionResult createnew(int courseID,Exam e)
        {
            e.InstructorId = int.Parse(User.FindFirst("UserId").Value);
            int exID= exam.insertAndGetId(e);
            List<Questionpool> questionpools = context.Questionpools.Where(c => c.CourseId == courseID).ToList();
            ExViewModel ex = new ExViewModel();
            ex.questionpools = new List<Questionpool>();
            ex.ExID = exID;
            ex.questionpools = questionpools;
            return View(ex);
        }
       // [Authorize(Roles = ("Admin"))]
       // [Authorize(Roles = ("Instructor"))]
        [Authorize(Roles = ("Instructor,Admin"))]
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
