using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public class AnswerRepository : IAnswer
    {
        private Context context;
        public AnswerRepository(Context _context )
        {
            context=_context;
        }
        public void Add(Answer answer)
        {
            context.Answers.Add(answer);
            context.SaveChanges();
        }

        public void Delete(int qid)
        {
            Answer ans=context.Answers.FirstOrDefault(e=>e.QuestionID==qid);
            context.Answers.Remove(ans);
            context.SaveChanges();
        }

        public List<Answer> GetAll()
        {
            return context.Answers.ToList();
        }

        public Answer GetAnswer(int id)
        {
            return context.Answers.FirstOrDefault(e => e.QuestionID == id);
        }

        public void Update(int qid,Answer answer)
        {
            Answer ans = context.Answers.FirstOrDefault(e => e.QuestionID == qid);
            ans.ans1txt=answer.ans1txt;
            ans.ans3txt=answer.ans3txt;
            ans.ans2txt=answer.ans2txt;
            ans.ans4txt= answer.ans4txt;
            context.SaveChanges();
        }
    }
}
