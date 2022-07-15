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

        public StudentController(IStudentRepository _student, ICourseReprository _couresRepo)
        {
            studentRepo = _student;
            couresRepo = _couresRepo;
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
        public IActionResult RegisterCourse()
        {
            //StudentCourse.get(id);
            List<Course> courses = couresRepo.GetAll();
            if (courses == null)
                return NotFound();
            return View(courses);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCourse(int id)
        {
            Course courses = couresRepo.GetById(id);
            if (courses == null)
                return NotFound();

            //StudentCourse.insert(id);
            return RedirectToAction("RegisterCourse");
        }
    }
}
