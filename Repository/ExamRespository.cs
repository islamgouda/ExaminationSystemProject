using ExaminationSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemProject.Repository
{
    public class ExamRespository : IExam
    {
        private Context context;
        private readonly IQuestion questionRepo;

        public ExamRespository(Context _context, IQuestion _question)
        {
            context = _context;
            questionRepo = _question;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetAll()
        {
            return context.Exams.Include(c => c.Course).Include(d=>d.Instructor).ToList();
            
        }

        public List<Exam> GetAllExamsByCourseID(int id)
        {
            throw new NotImplementedException();
        }

        public Exam GetByExamID(int id)
        {
            throw new NotImplementedException();
        }

        public Exam GetById(int id)
        {
            Exam x = context.Exams.FirstOrDefault(i => i.Id == id);
            return x;
        }

        public int insert(Exam exam)
        {
            context.Exams.Add(exam);
            context.SaveChanges();
            return (exam.Id);
        }
        public void AddQuestionsToExam(int EID, int QID)
        {
            ExamQuestions E = new ExamQuestions();
            E.ExamID = EID;
            E.QuestID = QID;
            context.ExamQuestions.Add(E);
            context.SaveChanges();
        }

        public void Update(int id, Exam exam)
        {
            throw new NotImplementedException();
        }

        public int insertAndGetId(Exam exam)
        {
            context.Exams.Add(exam);
            context.SaveChanges();
            return exam.Id;
        }
        public Exam GetByStudentIdWithCourse(int examID)
        {
            Exam exam = context.Exams.Include(c => c.Course).FirstOrDefault(i => i.Id == examID);
            return exam;
        }
        public List<Questionpool> GetQuistions(int examID)
        {
            List<Questionpool> Questions = new List<Questionpool>();
            List<ExamQuestions> exam = context.ExamQuestions.Where(i => i.ExamID == examID).ToList();

            foreach (var item in exam)
            {
                Questions.Add(questionRepo.GetById(item.QuestID));
            }
            return Questions;
        }
        public List<Exam> GetByInstructorID(int id)
        {
            return context.Exams.Where(e => e.InstructorId == id).ToList();
        }
    }
}
