using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Repository
{
    public class CrsResultRepository : ICrsResultRepository
    {
        private readonly AppDbContext context;

        public CrsResultRepository(AppDbContext _context)
        {
            context = _context;
        }
        public List<CrsResult> ShowAll()
        {
            return context.CrsResults.AsNoTracking().ToList();
        }
        public CrsResult GetById(int id)
        {
            return context.CrsResults.FirstOrDefault(c => c.Id == id);
        }
        public void Add(CrsResult entity)
        {
           context.CrsResults.Add(entity);
        }
        public void Update(CrsResult entity)
        {
            context.CrsResults.Update(entity);
        }
        public void Delete(int id)
        {
            context.CrsResults.Remove(GetById(id));
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
