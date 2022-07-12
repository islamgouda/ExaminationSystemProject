using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Get(int Id);

        List<Student> GetAllWithCourses();
        Student GetWithCourse(int Id);
        void Insert(Student Student);

        void Edit(int Id, Student Student);

        void Delete(int Id);


    }
}
