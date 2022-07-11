using Microsoft.AspNetCore.Mvc;
using ExaminationSystemProject.Repository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.ViewModel;
namespace ExaminationSystemProject.Controllers
{
    public class questionController : Controller
    {
        private IQuestion question;
        public questionController(IQuestion _question)
        {
            question = _question;
        }
        public IActionResult Index()
        {
            Questionpool questionpool = new Questionpool();
            questionpool.Questiontxt = "c++ is ";
            questionpool.CourseId = 4;
            questionpool.Degree = 10;
            questionpool.Correctanswer= "oop lang";
            questionpool.Type = "ms";
            Answer answer = new Answer();
            answer.ans1txt = "oop lang";
            answer.ans2txt = "assembly";
            answer.ans3txt = "web lang";
            answer.ans4txt = "ff";
            QuestionRepository qs = new QuestionRepository(new Context());
            qs.insert(questionpool,answer);

            return Content("hello");
            
        }
        [HttpGet]
        public IActionResult addquestion()
        {
            List<string> qlist = new List<string>();
            qlist.Add("Multichoose");
            qlist.Add("text");
            qlist.Add("trueFalse");
            return View(qlist);
        }
        [HttpPost]
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
    }
}
