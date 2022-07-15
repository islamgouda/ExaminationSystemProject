using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.ViewModel
{
    public class ExViewModel
    {
        public int ExID { get; set; }
        public List<Questionpool> questionpools { get; set; } 
    }
}
