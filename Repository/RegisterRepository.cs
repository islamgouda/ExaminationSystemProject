using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        Context context;
        public RegisterRepository(Context context)
        {
            this.context = context;
        }
        public void register(int course_id, int student_id)
        {
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseID = course_id;
            studentCourse.StudentID = student_id;
            context.studentCourses.Add(studentCourse);
            context.SaveChanges();
        }
    }
}
