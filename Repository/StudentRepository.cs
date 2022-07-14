using ExaminationSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context context;

        public StudentRepository(Context _context)
        {
            context = _context;
        }
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public Student Get(int Id)
        {
            return context.Students.FirstOrDefault(s => s.ID == Id);
        }
        public List<Student> GetAllWithCourses()
        {
            return context.Students.Include(x=>x.Courses).ToList();
        }

        public Student GetWithCourse(int Id)
        {
            return context.Students.Include(x => x.Courses).FirstOrDefault(s => s.ID == Id);
        }
        public void Insert(Student Student)
        {
            context.Students.Add(Student);
            context.SaveChanges();
        }
        public void Edit(int Id, Student Student)
        {
            Student std = Get(Id);
            std.Name = Student.Name;
            std.Address = Student.Address;
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            context.Students.Remove(Get(Id));
            context.SaveChanges();
        }

        public int InsertWithId(Student Student)
        {

            context.Students.Add(Student);

            context.SaveChanges();

            return (Student.ID);
        }
    }
}
