using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public class StudentExamRepository : IStudentExamRepository
    {
        private readonly Context context;
        private readonly IExam examRepo;

        public StudentExamRepository(Context _context, IExam _examRepo)
        {
            context = _context;
            examRepo = _examRepo;
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

        public List<Exam> GetStudentExams(int StdId)
        {
            List<int> student_Exam_IDs = context.student_Exams.Where(s => s.StudentID == StdId)
                                                              .Select(s => s.ExamID).ToList();
            List<Exam> exams = new List<Exam>();
            foreach (var item in student_Exam_IDs)
            {
                exams.Add(examRepo.GetByStudentIdWithCourse(item));
            }
            return exams;
        }




    }
}
