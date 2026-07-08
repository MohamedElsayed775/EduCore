using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Repository
{
    public class CourseRepository : ICourseRepository
    {
        AppDbContext context;
        public CourseRepository(AppDbContext _context)
        {
            context = _context ;
        }
        public List<Course> ShowAll()
        {
            return context.Courses.AsNoTracking().ToList(); ;
        }
        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(a => a.Id == id);
        }
        public void Add(Course entity)
        {
            context.Courses.Add(entity);
        }
        public void Update( Course entity)
        {
            Course course = GetById(entity.Id);
            if (course != null)
            {
                course.Name = entity.Name;
                course.Degree = entity.Degree;
                course.MinDegree = entity.MinDegree;
                course.Hours = entity.Hours;
                course.DepartmentId = entity.DepartmentId;
                context.Courses.Update(course);
            }
        }
        public void Delete(int id)
        {
            context.Courses.Remove(GetById(id));
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
