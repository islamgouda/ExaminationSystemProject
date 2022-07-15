using ExaminationSystem.Reprository;
using ExaminationSystemProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{

    [Authorize(Roles = ("Admin"))]
    public class CourseController : Controller
    {
        ICourseReprository courseReprository;

        public CourseController(ICourseReprository _courseReprository)
        {
            this.courseReprository = _courseReprository;
        }








        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult Index()
        {
            List<Course> courses = courseReprository.GetAll();
            return View("Index",courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courseReprository.Create(course);   
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]

        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult Details(int Id)
        {
            Course course = courseReprository.GetById(Id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            Course course=courseReprository.GetById(id);

            if (id == null)
            {
                return NotFound();  
            }
            return View(course);

        }
        [HttpPost]
        public IActionResult Edit(int id,Course Newcourse)
        {
            Course oldCourse = courseReprository.GetById(id);

            if (Newcourse.Name != null)
            {
                oldCourse.Name = Newcourse.Name;
                oldCourse.MaxDegree = Newcourse.MaxDegree;
                oldCourse.MinDegree = Newcourse.MinDegree;
                oldCourse.Description = Newcourse.Description;
                oldCourse.InstructorID = Newcourse.InstructorID;

                courseReprository.Edit(id,Newcourse);
                return RedirectToAction("Index");
            }

            return View(Newcourse);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course course = courseReprository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = courseReprository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            courseReprository.Delete(id);
            return RedirectToAction("Index");


        }



    }
}
