using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemProject.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public Context() : base()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source =.;Initial Catalog =myExamination;Integrated security=true");
        }
        //DESKTOP-RBFSHHC\\SQLEXPRESS
        //DESKTOP-JT45RDG
        public DbSet<Questionpool>Questionpools { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestions>ExamQuestions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_Exam> student_Exams { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

    }
}
