using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemProject.Models
{
    public class ExamQuestions
    {
        public int ID { get; set; }
       // [Column(Order = 0)]
        [ForeignKey("Questionpool")]
        public int QuestID { set; get; }

        
      //  [Column(Order = 1)]
        [ForeignKey("Exam")]
        public int ExamID { set; get; }
        public virtual Exam? Exam { set; get; }
        public virtual Questionpool? Questionpool { set; get; }

    }
}
