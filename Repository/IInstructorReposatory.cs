
using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Reposatories
{
    public interface IInstructorReposatory
    {
        List<Instructor> Getall();

        Instructor GetById(int Id);

        Instructor GetInstructorByName(string name);

        bool InsertInstructor(Instructor e);
        int InsertWithId(Instructor e);

        void DeleteInstructor(int id);

        void Edit(int Id, Instructor instructor);
        List<Exam> AllInsExams(int id);



    }
}
