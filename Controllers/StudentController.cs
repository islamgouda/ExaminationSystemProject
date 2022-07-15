using ExaminationSystem.Reprository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using ExaminationSystemProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepo;
        private readonly ICourseReprository couresRepo;
        private readonly IRegisterRepository registerRepo;
        private readonly IStudentExamRepository stdExamRrpo;

        public StudentController(IStudentRepository _student, ICourseReprository _couresRepo,
                                 IRegisterRepository _registerRepo, IStudentExamRepository _stdExamRrpo)
        {
            studentRepo = _student;
            couresRepo = _couresRepo;
            registerRepo = _registerRepo;
            stdExamRrpo = _stdExamRrpo;
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

        public IActionResult Details(int id)
        {
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCourse(int id ,int[] checkedCourses)
        {
            foreach (int Mycourse in checkedCourses)
            {
                registerRepo.register(Mycourse, id);
            }

            return RedirectToAction("RegisterCourse");
        }

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

        public IActionResult ShowExams(int id)
        {
            ViewBag.StdExamID = id;
            ViewBag.StdCrsID = id;
            ViewBag.hasExam = true;
            List<Exam> myExams = stdExamRrpo.GetStudentExams(id);
            if(myExams.Count == 0)
                ViewBag.hasExam = false;
            return View(myExams);
        }
    }
}
