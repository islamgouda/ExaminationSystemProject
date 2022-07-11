using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public class ExamRespository : IExam
    {
        private Context context;
        public ExamRespository(Context _context)
        {
            context= _context;

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetAll()
        {
            return context.Exams.ToList();
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
            throw new NotImplementedException();
        }

        public void insert(Exam exam)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
