using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.ViewModel
{
    public class SelectQuestionViewModel
    {
        public List<ExamQuestions> ExamQuestions { get; set; }
        public Exam exam { get; set; }
    }
}
