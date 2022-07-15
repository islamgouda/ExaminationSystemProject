using ExaminationSystemProject.Models;
namespace ExaminationSystemProject.Repository
{
    public interface IExam
    {
        public int insert(Exam exam);
        public int insertAndGetId(Exam exam);
        public void Update(int id, Exam exam);
        public Exam GetById(int id);
        public Exam GetByExamID(int id);
        public List<Exam> GetAllExamsByCourseID(int id);
        public List<Exam> GetAll();
        public void Delete(int id);
        public void AddQuestionsToExam(int EID, int QID);
        Exam GetByStudentIdWithCourse(int stdID);
        List<Questionpool> GetQuistions(int examID);
    }
}
