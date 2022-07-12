using ExaminationSystemProject.Models;
namespace ExaminationSystemProject.Repository
{
    public interface IQuestion
    {
        public void insert(Questionpool questionpool);
        public void insert(Questionpool questionpool, Answer answer);
        public void Update(int id ,Questionpool questionpool);
        public Questionpool GetById(int id);
        public Questionpool GetByCourseID(int courseID);
        public List<Questionpool> GetAllByCourseID(int courseID);
        public List<Questionpool> GetAll();
        public void Delete(int id);

    }
}
