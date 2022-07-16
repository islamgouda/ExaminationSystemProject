using ExaminationSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemProject.Reposatories
{
    public class InstructorRepository : IInstructorReposatory
    {
        private readonly Context context;

        public InstructorRepository(Context _context)
        {
            context = _context;
        }

        public List<Exam> AllInsExams(int id)
        {
            List < Exam > res=new List<Exam>();
            res = context.Exams.Include(c=>c.Course).Where(i=>i.InstructorId==id).ToList();
            return res;
        }


        public List<Instructor> Getall()
        {
            return this.context.Instructors.ToList();
        }

        public Instructor GetById(int Id)
        {
            return context.Instructors.FirstOrDefault(x => x.ID == Id);

        }
        public Instructor GetInstructorByName(string name)
        {
            return this.context.Instructors.FirstOrDefault(inst => inst.Name == name);

        }

        public bool InsertInstructor(Instructor e)
        {
            try
            {
                Instructor newIns = new Instructor()
                {
                    ID = e.ID,
                    Name = e.Name,
                    Address = e.Address,
                };
                this.context.Instructors.Add(newIns);
                this.context.SaveChanges();

            }
            catch
            {
                return false;

            }
            return true;

        }

        public void Edit(int Id, Instructor instructor)
        {
                Instructor std = GetById(Id);
                std.Name = instructor.Name;
                std.Address = instructor.Address;
                context.SaveChanges();
        }


        public bool DeleteInstructor(int id)
        {

            Instructor instructor = context.Instructors.Find(id);
            bool msg;
            context.Instructors.Remove(instructor);
            try
            {
                context.SaveChanges();
                msg = true;
            }
            catch(Exception e)
            {
                 msg=false ;
            }
            return msg;

        }

       public int InsertWithId(Instructor e)
        {
            context.Instructors.Add(e);
            context.SaveChanges();
            return (e.ID);
        }



    }
}