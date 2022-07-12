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
            context.Courses.Update(course);
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
    }
}
