using System.ComponentModel.DataAnnotations;
namespace ExaminationSystemProject.ViewModel
{
    public class TFquestion
    {
        public string Questiontxt { get; set; }
        [Display(Name = "True Or False")]
        public Boolean Correctanswer { get; set; }
        
        public int Degree { get; set; }
        public int CourseId { get; set; }
       
    }
}
