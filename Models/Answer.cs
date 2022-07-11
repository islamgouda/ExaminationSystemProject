using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemProject.Models
{
    public class Answer
    {
        [Key]
        [ForeignKey("Questionpool")]
        
        public int QuestionID { get; set; }
        public string? ans1txt { get; set; }
        public string? ans2txt { get; set; }
        public string? ans3txt { get; set; }
        public string? ans4txt { get; set; }
        public Questionpool? Questionpool { get; set; }
     
    }
}
