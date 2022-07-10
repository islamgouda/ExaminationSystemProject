namespace ExaminationSystemProject.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string adress { get; set; }
        public virtual List<Exam>? Exams { get; set; }

        public virtual List<Course>?Courses { get; set; }
    }
}
