using ExaminationSystemProject.Models;

namespace MVC.Reposatories
{
    public class InstructorRepository : IInstructorReposatory
    {
        private readonly Context context;

        public InstructorRepository(Context _context)
        {
            context = _context;
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
            context.Instructors.Update(instructor);
            context.SaveChanges();

        }


        public void DeleteInstructor(int id)
        {

            Instructor instructor = context.Instructors.Find(id);

            context.Instructors.Remove(instructor);
            context.SaveChanges();


        }

       
    }
}