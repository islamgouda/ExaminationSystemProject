
using ExaminationSystemProject.Models;

namespace MVC.Reposatories
{
    public interface IInstructorReposatory
    {
        List<Instructor> Getall();

        Instructor GetById(int Id);

        Instructor GetInstructorByName(string name);

        bool InsertInstructor(Instructor e);

        void DeleteInstructor(int id);

        void Edit(int Id, Instructor instructor);



    }
}
