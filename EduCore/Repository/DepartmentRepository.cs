using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        AppDbContext context;
        public DepartmentRepository(AppDbContext _context)
        {
            context = _context;
        }
        public List<Department> ShowAll()
        {
            return context.Departments.AsNoTracking().ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d=>d.Id==id);
        }
        public void Add(Department entity)
        {
           context.Departments.Add(entity);
        }
        public void Update(Department entity)
        {
            context.Departments.Update(entity);
        }
        public void Delete(int id)
        {
            context.Departments.Remove(GetById(id));
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
