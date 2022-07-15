
using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    
    public class QuestionRepository : IQuestion
    {
        Context context;
        public QuestionRepository(Context con)
        {
            context = con;
        }
            public void Delete(int id)
        {
            context.Questionpools.Remove(context.Questionpools.FirstOrDefault(e=>e.ID==id));
        }

        public List<Questionpool> GetAll()
        {
            return context.Questionpools.ToList();
        }
      
        public List<Questionpool> GetAllByCourseID(int courseID)
        {
            return context.Questionpools.Where(e=>e.CourseId==courseID).ToList();   
        }

        public Questionpool GetByCourseID(int courseID)
        {
            return context.Questionpools.FirstOrDefault(e => e.CourseId == courseID);
        }

        public Questionpool GetById(int id)
        {
           Questionpool qs= context.Questionpools.Where(t => t.ID == id).FirstOrDefault();
            return qs;
        }

        public void insert(Questionpool questionpool)
        {
            context.Questionpools.Add(questionpool);
            context.SaveChanges();
        }
        public void insert(Questionpool questionpool,Answer answer)
        {
            context.Questionpools.Add(questionpool);
            context.SaveChanges();
            if (questionpool.Type == "ms")
            {
              //  Questionpool q=context.Questionpools.Where(r=>r.Type=="ms").First(e=>e.Questiontxt==questionpool.Questiontxt);
                answer.QuestionID = questionpool.ID;
                context.Answers.Add(answer);
                context.SaveChanges();
            }
           
           

        }

        public void Update(int id, Questionpool questionpool)
        {
            Questionpool old = context.Questionpools.FirstOrDefault(e => e.ID == id);
            if(old != null) {
                old.Questiontxt = questionpool.Questiontxt;
                old.Degree = questionpool.Degree;
                old.Correctanswer = questionpool.Correctanswer;
                old.CourseId = questionpool.CourseId;
                context.SaveChanges();
            }
            else
            {
                context.Questionpools.Add(questionpool);

                context.SaveChanges();
            }
            
        }

       
    }
}
