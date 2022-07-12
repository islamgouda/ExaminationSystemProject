using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public class StudentExamRepository : IStudentExamRepository
    {
        private readonly Context context;

        public StudentExamRepository(Context _context)
        {
            context = _context;
        }
        public List<Student_Exam> GetAll()
        {
            return context.student_Exams.ToList();
        }
        public Student_Exam Get(int Id)
        {
            return context.student_Exams.FirstOrDefault(s => s.Id == Id);
        }

        public void Insert(Student_Exam StudentExam)
        {
            context.student_Exams.Add(StudentExam);
            context.SaveChanges();
        }
        public void Edit(int Id, Student_Exam StudentExam)
        {
            Student_Exam student_Exam = Get(Id);
            student_Exam.ExamID = StudentExam.ExamID;
            student_Exam.StudentID = StudentExam.StudentID;
            student_Exam.StudentDegree = StudentExam.StudentDegree;
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            context.student_Exams.Remove(Get(Id));
            context.SaveChanges();
        }

        

        

        
    }
}
