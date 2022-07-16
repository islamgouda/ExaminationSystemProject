using ExaminationSystem.Reprository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.Reposatories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemProject.Controllers
{

   // [Authorize(Roles = ("Admin"))]
    public class CourseController : Controller
    {
        ICourseReprository courseReprository;
        private readonly IInstructorReposatory instructorReposatory;

        public CourseController(ICourseReprository _courseReprository,IInstructorReposatory _instructorReposatory)
        {
            this.courseReprository = _courseReprository;
            instructorReposatory = _instructorReposatory;
        }








        [Authorize(Roles = ("Instructor,Admin"))]

        [HttpGet]

        public IActionResult Index()
        {
            
            return View(courseReprository.GetAll());
        }
        [Authorize(Roles = ("Admin"))]
        public IActionResult Create()
        {
            ViewData["InstrutorList"] = instructorReposatory.Getall();
                //context.Courses.ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courseReprository.Create(course);   
                return Redirect("Index");
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
        [Authorize(Roles = ("Admin"))]
        public IActionResult Edit(int id)
        {
           
            Course course=courseReprository.GetById(id);
            ViewData["InstrutorList"] = instructorReposatory.Getall();

            //if (course == null)
            //{
            //    return NotFound();  
            //}
            return View(course);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ("Admin"))]
        public IActionResult Edit(int id,Course Newcourse)
        {
            Course oldCourse = courseReprository.GetById(id);

            //if (Newcourse.Name != null)
            
                oldCourse.Name = Newcourse.Name;
                oldCourse.MaxDegree = Newcourse.MaxDegree;
                oldCourse.MinDegree = Newcourse.MinDegree;
                oldCourse.Description = Newcourse.Description;
                oldCourse.InstructorID = Newcourse.InstructorID;

                courseReprository.Edit(id, Newcourse);

                return RedirectToAction("Index");

            

        }


        [HttpGet]
        [Authorize(Roles = ("Admin"))]
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
            ViewData["InstrutorList"] = instructorReposatory.Getall();

            return View(course);
        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
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
