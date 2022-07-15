using Microsoft.AspNetCore.Mvc;
using ExaminationSystemProject.Repository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace ExaminationSystemProject.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class questionController : Controller
    {
       

        private IQuestion question;
        public questionController(IQuestion _question)
        {
            question = _question;
        }
        [Authorize(Roles = ("Instructor"))]
        public IActionResult Index()
        {
            //Questionpool questionpool = new Questionpool();
            //questionpool.Questiontxt = "c++ is ";
            //questionpool.CourseId = 4;
            //questionpool.Degree = 10;
            //questionpool.Correctanswer= "oop lang";
            //questionpool.Type = "ms";
            //Answer answer = new Answer();
            //answer.ans1txt = "oop lang";
            //answer.ans2txt = "assembly";
            //answer.ans3txt = "web lang";
            //answer.ans4txt = "ff";
            //QuestionRepository qs = new QuestionRepository(new Context());
            //qs.insert(questionpool,answer);
            List<Questionpool> questionpools = question.GetAll();
            return View(questionpools);
            
        }
        Context c = new Context();

        [Authorize(Roles = ("Instructor"))]
        public IActionResult GetQuestions(int CourseID)
        {
            return Json(c.Questionpools.Where(i => i.CourseId == CourseID).ToList());
        }
        

        [HttpGet]

        [Authorize(Roles = ("Instructor"))]
        public IActionResult addquestion()
        {
            List<string> qlist = new List<string>();
            qlist.Add("Multichoose");
            qlist.Add("text");
            qlist.Add("trueFalse");
            return View(qlist);
        }
        [HttpPost]

        [Authorize(Roles = ("Instructor"))]
        public IActionResult addnewquestion(string type)
        {
            if (type == "ms") {
                return View("multichoose");
            }
            else if(type=="tf")
            {
                return View("truefalse");
            }
            else  {
                return View("text");
            }
            
            
        }

        [Authorize(Roles = ("Instructor"))]
        public IActionResult multichoose(Msquestion msquestion)
        {
            Questionpool questionpool = new Questionpool();
            Answer answer = new Answer();
            questionpool.Questiontxt= msquestion.Questiontxt;
            questionpool.Correctanswer=msquestion.Correctanswer;
            questionpool.Degree=msquestion.Degree;
            questionpool.CourseId=msquestion.CourseId;
            questionpool.Type = "ms";
            answer.ans1txt=msquestion.ans1txt;
            answer.ans2txt = msquestion.ans2txt;
            answer.ans3txt = msquestion.ans3txt;
            answer.ans4txt = msquestion.ans4txt;
            QuestionRepository qs = new QuestionRepository(new Context());
            question.insert(questionpool, answer);
            return Content("saved");
        }

        [Authorize(Roles = ("Instructor"))]
        public IActionResult truefalse(TFquestion tfquestion)
        {
            Questionpool questionpool = new Questionpool();
            questionpool.Questiontxt = tfquestion.Questiontxt;
            questionpool.Degree = tfquestion.Degree;
            questionpool.Correctanswer = tfquestion.Correctanswer ? "True" : "False";
            questionpool.CourseId = tfquestion.CourseId;
            questionpool.Type = "tf";
            question.insert(questionpool);
            return Content("Saved");
        }

        [Authorize(Roles = ("Instructor"))]
        public IActionResult text(txtQuestion txtQuestion)
        {
            Questionpool questionpool=new Questionpool();
            questionpool.Questiontxt=txtQuestion.Questiontxt;
            questionpool.Correctanswer = txtQuestion.Correctanswer;
            questionpool.Degree = txtQuestion.Degree;
            questionpool.CourseId = txtQuestion.CourseId;
            questionpool.Type = "txt";
            question.insert(questionpool);
            return Content("saved");
        }

        [HttpGet]

        [Authorize(Roles = ("Instructor"))]

        public IActionResult Detais(int id)
        {
            return View();
        }

        

        public IActionResult edit(int qid)
        {

            Context con = new Context();
            Questionpool questionp = question.GetById(qid);
            if (questionp != null) { return View(questionp); }
            return NotFound();
            

        }


        [Authorize(Roles = ("Instructor"))]
        [HttpPost]
        public IActionResult edit(Questionpool ques)

        
        public IActionResult update(int id,Questionpool ques)

        {
            if (ModelState.IsValid==true)
            {
                question.Update(id,ques);
              return  RedirectToAction("Index");

            }
            return View("edit",ques);

        }
    }
}
