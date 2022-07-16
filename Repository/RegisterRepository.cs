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

        
        public List<StudentCourse> getStudentCourses(int student_id)
        {

            return context.studentCourses.Where(s => s.StudentID==student_id).ToList();
        
        }

        public void register(int course_id, int student_id)
        {
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseID = course_id;
            studentCourse.StudentID = student_id;
            context.studentCourses.Add(studentCourse);
            context.SaveChanges();
        }


        public void deleteCourse(int course_id, int student_id)
        {

            StudentCourse studentCourse = context.studentCourses.Where(c => c.CourseID == course_id)
                                                                        .Where(c => c.StudentID == student_id).FirstOrDefault();
            
            context.studentCourses.Remove(studentCourse);
            
            context.SaveChanges();


        }
        public List<StudentCourse> GetStudentCoursesbyCourseID(int id)
        {
            List<StudentCourse> studentCourseList = context.studentCourses.Where(e => e.CourseID == id).ToList();
            return studentCourseList;
        }


    }
}
