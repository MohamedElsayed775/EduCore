using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace EduCore.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext context;

        public InstructorRepository(AppDbContext _Context )
        {
            context = _Context;
        }
        public List<Instructor> ShowAll()
        {
            return context.Instructors.Include(i => i.Course).Include(i => i.Department).AsNoTracking().ToList();
        }
        public Instructor GetById(int id)
        {
            return context.Instructors.Include(i => i.Course).Include(i => i.Department).FirstOrDefault(i => i.Id == id);
        }
        public void Add(Instructor entity)
        {
           context.Instructors.Add(entity); 
        }
        public void Update(Instructor entity)
        {
            context.Instructors.Update(entity);
        }

        public void Delete(int id)
        {
            context.Instructors.Remove(GetById(id));
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
