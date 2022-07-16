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
        List<Exam> GetStudentExams(int StdId);
        void SetStudentDegree(int StdID, int ExamID, int degree);
        List<Student_Exam> GetByStudentID(int stdID);
    }
}
