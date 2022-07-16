//using ExaminationSystem.Models;
using ExaminationSystemProject.Models;

namespace ExaminationSystem.Reprository
{
    public class CourseReprository : ICourseReprository
    {
        Context context;
        public CourseReprository(Context context)
        {
            this.context = context;
        }

        public void Create(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Course course = context.Courses.Find(Id);

            context.Courses.Remove(course);
            context.SaveChanges();

        }

        public void Edit(int Id, Course course)
        {
            Course co = GetById(Id);
            co.Name = course.Name;
            co.MinDegree = course.MinDegree;
            co.MaxDegree = course.MaxDegree;
            co. Description = course.Description;
            co.InstructorID = course.InstructorID;

            context.SaveChanges();


        }
        public List<Course> GetAll()
        {
            return context.Courses.ToList();

        }

        public Course GetById(int Id)
        {
            return context.Courses.FirstOrDefault(x => x.ID == Id);

        }
        public List<Course> GetCoursesByInstructorID(int id)
        {
            List<Course> co = context.Courses.Where(e => e.InstructorID == id).ToList();
            return co;
        }
        ////new Repository
    }
}
