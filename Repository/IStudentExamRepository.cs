using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public interface IStudentExamRepository
    {
        List<Student_Exam> GetAll();
        Student_Exam Get(int Id);

        void Insert(Student_Exam StudentExam);

        void Edit(int Id, Student_Exam StudentExam);

        void Delete(int Id);
    }
}
