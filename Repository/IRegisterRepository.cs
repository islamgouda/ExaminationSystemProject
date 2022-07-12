using ExaminationSystemProject.Models;

namespace ExaminationSystemProject.Repository
{
    public interface IRegisterRepository 
    {
        void register(int course_id, int student_id);

        List<StudentCourse> getStudentCourses(int student_id);

        void deleteCourse(int course_id, int student_id);


    }
}
