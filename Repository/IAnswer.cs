using ExaminationSystemProject.Models;
namespace ExaminationSystemProject.Repository
{
    public interface IAnswer
    {
        public Answer GetAnswer(int id);
        public void Add(Answer answer);
        public void Update(int qid,Answer answer);
        public void Delete(int qid);
        public List<Answer> GetAll();
    }
}
