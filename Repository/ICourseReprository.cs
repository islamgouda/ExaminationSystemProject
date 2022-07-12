using ExaminationSystem.Models;


namespace ExaminationSystem.Reprository
{
    public interface ICourseReprository
    {
        List<Course> GetAll();
        Course GetById(int Id);

        void Create(Course course);

        void Edit(int Id, Course course);

        void Delete(int Id);




    }
}
