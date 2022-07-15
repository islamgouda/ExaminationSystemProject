using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ExaminationSystemProject.Models;
using MVC.Reposatories;
using Microsoft.AspNetCore.Authorization;

namespace My_Tasks.Controllers
{

    [Authorize(Roles = ("Admin"))]
    public class InstrctorController : Controller
    {
        private readonly IInstructorReposatory instructorReposatory;

        public InstrctorController(IInstructorReposatory _instructorReposatory)
        {
            this.instructorReposatory = _instructorReposatory;

        }

        [Authorize(Roles = ("Instructor"))]
        //Instrctor/Indexx
        public IActionResult Indexx()
        {
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetInstructors()
        {
            List<Instructor> instructors = instructorReposatory.Getall();
            return View("GetInstructors", instructors);
        }


        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult Details(int id)
        {
            if (User.IsInRole("Admin"))
            {
                if (instructorReposatory.GetById(id) != null)
                {
                    return View(instructorReposatory.GetById(id));

                }
                return RedirectToAction("Indexx");
            }
            else if (User.IsInRole("Instructor"))
            {
                int id2 = int.Parse(User.FindFirst("UserId").Value);
                if (instructorReposatory.GetById(id2) != null)
                {
                    return View(instructorReposatory.GetById(id));

                }
                
            }
            return RedirectToAction("Indexx");



        }

        [Authorize(Roles = ("Instructor,Admin"))]
        public IActionResult ShowInstructorCourseAndExams(int id)
        {
            if (User.IsInRole("Admin"))
            {
                List<Exam> res = instructorReposatory.AllInsExams(id);
                if (res.Count()>0)
                    return View(res);
                else
                    return Content("NoExams found");
            }
            else
            {
                int id2 = int.Parse(User.FindFirst("UserId").Value);
                List<Exam> res = instructorReposatory.AllInsExams(id2);
                if (res.Count() > 0)
                    return View(res);
                else
                    return Content("NoExams found");
            }
            return RedirectToAction("Indexx");

        }



        [HttpGet("{id:int}")]

        public IActionResult FindInstrucor(int id)
        {
            if (instructorReposatory.GetById(id) == null)
            {
                return View("PageNotFound");
            }
            return View(instructorReposatory.GetById(id));

        }

        [HttpGet("{name:alpha}")]

        public IActionResult FindInstructorByName(string name)
        {
            if (instructorReposatory.GetInstructorByName(name) == null)
            {
                return View("PageNotFound");
            }
            return View(instructorReposatory.GetInstructorByName(name));


        }



        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View("AddInstructor");
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor i)
        {
            if (ModelState.IsValid == true)

            {
                instructorReposatory.InsertInstructor(i);
                return RedirectToAction("GetInstructors");

            }

            else
            {
                return View("AddInstructor", i);
            }

        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor ins = instructorReposatory.GetById(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(ins);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Instructor ins)
        {
            Instructor old = instructorReposatory.GetById(id);

            if (ins.Name != null)
            {
                old.Name = ins.Name;
                old.Address = ins.Address;

                instructorReposatory.Edit(id, ins);

                return RedirectToAction("GetInstructors");
            }


            return View("Edit", ins);
        }


        public IActionResult DeleteInstructor(int id)
        {
            instructorReposatory.DeleteInstructor(id);
           
            return RedirectToAction("GetInstructors");

        }






    }
}
