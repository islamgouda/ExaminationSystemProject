using ExaminationSystem.Reprository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepo;
        private readonly ICourseReprository couresRepo;
        private readonly IExam examRepo;
        private readonly IRegisterRepository registerRepo;
        private readonly IStudentExamRepository stdExamRrpo;
        private readonly IAnswer answerRepo;

        public StudentController(IStudentRepository _student, ICourseReprository _couresRepo, IExam _exam,
            IRegisterRepository _registerRepo, IStudentExamRepository _stdExamRrpo, IAnswer answerRepo)
        {
            studentRepo = _student;
            couresRepo = _couresRepo;
            examRepo = _exam;
            registerRepo = _registerRepo;
            stdExamRrpo = _stdExamRrpo;
            this.answerRepo = answerRepo;
        }

        public IActionResult Index()
        {
            return View(studentRepo.GetAll());
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(StudentVM newStudentVM)
        {
            if (ModelState.IsValid)
            {
                if (newStudentVM != null)
                {
                    Student student = new Student
                    {
                        Name = newStudentVM.Name,
                        Address = newStudentVM.Address
                    };
                    studentRepo.Insert(student);
                }
            }
            
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = ("Student"))]
        public IActionResult Details(int id)
        {
            //int id= int.Parse(User.FindFirst("UserId").Value);
            return View(studentRepo.Get(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = studentRepo.Get(id);
            if (student == null)
                return NotFound();
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudentVM oldStudentVM)
        {
            Student student = new Student
            {
                Name = oldStudentVM.Name,
                Address = oldStudentVM.Address
            };
            studentRepo.Edit(id, student);
            return Redirect("/Student/Index");
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Student student = studentRepo.Get(id);
            if (student == null)
                return NotFound();
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            if (studentRepo.Get(id) == null)
                return NotFound();
            studentRepo.Delete(id);
            return Redirect("/Student/Index");
        }
        //[Authorize(Roles = ("Student"))]
        [HttpGet]
        public IActionResult RegisterCourse(int id)
        {
            ViewBag.StdID = id;
            ViewBag.isEnrolled = true;
            List<int> coursesIDs = registerRepo.getStudentCourses(id).Select(c=>c.CourseID).ToList();
            List<Course> Enroledcourses = new List<Course>();
            foreach (var item in coursesIDs)
            {
                Enroledcourses.Add(couresRepo.GetById(item));
            }
            List<Course> AllCourses = couresRepo.GetAll();
            if (AllCourses == null)
            {
                return NotFound();
            }
            if (Enroledcourses.Count == 0)
            {
                return View(AllCourses);
            }
            if (AllCourses.Count == Enroledcourses.Count)
            {
                ViewBag.isEnrolled = false;
            }
            List<Course> NotEnroledcourses = new List<Course>();

            foreach (Course course in AllCourses)
            {
                    if (!Enroledcourses.Contains(course))
                        NotEnroledcourses.Add(course);
            }
            return View(NotEnroledcourses);
        }
        //[Authorize(Roles = ("Student"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCourse(int id ,int[] checkedCourses)
        {
            foreach (int Mycourse in checkedCourses)
            {
                registerRepo.register(Mycourse, id);
            }

            return Redirect($"/Student/RegisterCourse/{id}");
        }
        //[Authorize(Roles = ("Student"))]

        public IActionResult ShowCourses(int id)
        {
            ViewBag.StdCrsID=id;
            List<int> coursesIDs = registerRepo.getStudentCourses(id).Select(c => c.CourseID).ToList();
            List<Course> Enroledcourses = new List<Course>();
            foreach (var item in coursesIDs)
            {
                Enroledcourses.Add(couresRepo.GetById(item));
            }
            return View(Enroledcourses);
        }
        //[Authorize(Roles = ("Student"))]
        public IActionResult ShowExams(int id)
        {
            ViewBag.StdExamID = id;
            ViewBag.StdCrsID = id;
            ViewBag.hasExam = true;
            List<Exam> myExams = stdExamRrpo.GetStudentExams(id);
            List<Student_Exam> student_Exams = stdExamRrpo.GetByStudentID(id);
            foreach (var item in student_Exams)
            {
                if (item.StudentDegree > 0)
                    ViewData[item.ExamID.ToString()] = true;
                else
                    ViewData[item.ExamID.ToString()] = false;
            }
            if(myExams.Count == 0)
                ViewBag.hasExam = false;
            return View(myExams);
        }
        //[Authorize(Roles = ("Student"))]
        [HttpGet]
        public IActionResult SolveExam(int ExamID, int StdID)
        {
            ViewBag.examID = ExamID;
            ViewBag.StdID = StdID;
            ExamAnswerViewModel examAnswerVM = new ExamAnswerViewModel();

            examAnswerVM.Questionpools = examRepo.GetQuistions(ExamID);
            Answer answers;
            examAnswerVM.Answers = new List<Answer>();
            foreach (var item in examAnswerVM.Questionpools)
            {
                if (item.Type == "ms")
                {
                    examAnswerVM.Answers.Add(answerRepo.GetAnswer(item.ID));
                }
            }
            return View(examAnswerVM);
        }
        //[Authorize(Roles = ("Student"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SolveExam(int ExamID,int StdID, Dictionary<int, string> answers) //string[] 
        {
            int sum = 0;
            //int stdID = 1;
            List<Questionpool> ExamQuestion = examRepo.GetQuistions(ExamID);
            foreach (var item in ExamQuestion)
            {
                if (answers.ContainsKey(item.ID))
                {
                    if (item.Type == "tf")
                    {
                        if (answers[item.ID] == item.Correctanswer)
                        {
                            sum += item.Degree;
                        }
                    }
                    else if (item.Type == "txt")
                    {
                        if (answers[item.ID] == item.Correctanswer)
                        {
                            sum += item.Degree;
                        }
                    }
                    else if (item.Type == "ms")
                    {
                        if (answers[item.ID] == item.Correctanswer)
                        {
                            sum += item.Degree;
                        }
                    }

                }
            }
            stdExamRrpo.SetStudentDegree(StdID, ExamID, sum);
            ViewData[ExamID.ToString()] = true;
            return Redirect($"/Student/ShowExams/{StdID}");
        }

        //////////////////////////////////////////////////////////////////
        public IActionResult ShowResult(int ExamID, int StdID)
        {
            ViewBag.StdID = StdID;
            ExamResultViewModel examResultVM = new ExamResultViewModel();
            Student_Exam student_Exam = stdExamRrpo.GetStudentExam(StdID , ExamID);
            Course course = examRepo.GetByIdWithCourse(ExamID).Course;
            examResultVM.studentName = studentRepo.Get(StdID).Name;
            examResultVM.CourseName = course.Name;
            examResultVM.studentDegree = student_Exam.StudentDegree;
            if (student_Exam.StudentDegree >= course.MinDegree)
                examResultVM.isPassed = true;
            else
                examResultVM.isPassed = false;
            return View(examResultVM);
        }

    }
    
}
