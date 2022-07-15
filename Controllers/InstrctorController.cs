using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ExaminationSystemProject.Models;
using MVC.Reposatories;

namespace My_Tasks.Controllers
{
    public class InstrctorController : Controller
    {
        private readonly IInstructorReposatory instructorReposatory;

        public InstrctorController(IInstructorReposatory _instructorReposatory)
        {
            this.instructorReposatory = _instructorReposatory;

        }
        [HttpGet]
        public IActionResult GetInstructors()
        {
            List<Instructor> instructors = instructorReposatory.Getall();
            return View("GetInstructors", instructors);
        }


        public IActionResult Details(int id)
        {
            if (instructorReposatory.GetById(id) != null)
            {
                return View(instructorReposatory.GetById(id));

            }
            return RedirectToAction("GetInstructors");

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

            if (ins == null)
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

          //  if (ins.Name != null)
            //{
                old.Name = ins.Name;
                old.Address = ins.Address;

                instructorReposatory.Edit(id, ins);

                return RedirectToAction("GetInstructors");
            //}


        }


        public IActionResult DeleteInstructor(int id)
        {
            instructorReposatory.DeleteInstructor(id);
           
            return RedirectToAction("GetInstructors");

        }






    }
}
