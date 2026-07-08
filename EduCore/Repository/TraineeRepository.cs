using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Models.ViewModel;
using EduCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly AppDbContext context;

        public TraineeRepository(AppDbContext _context)
        {
            context = _context;
        }
        public List<Trainee> ShowAll()
        {
            return context.Trainees.Include(t => t.Department).AsNoTracking().ToList();
        }
        public Trainee GetById(int id)
        {
            return context.Trainees.Include(t => t.Department).FirstOrDefault(t => t.Id == id);
        }
        public void Add(Trainee entity)
        {
            context.Trainees.Add(entity);
        }
        public void Update(Trainee entity)
        {
            context.Trainees.Update(entity);
        }
        public void Delete(int id)
        {
            context.Trainees.Remove(GetById(id));
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        public List<ResultsViewModel> GetResults(int traineeId)
        {
            return context.CrsResults.Where(cr => cr.TraineeId == traineeId).Select(cr => new ResultsViewModel
            {
                CourseName = cr.Course.Name,
                Degree = cr.Degree,
                MinDegree = cr.Course.MinDegree,
                status = cr.Degree >= cr.Course.MinDegree ? "Pass" : "Failed"
            }).ToList();
        }
    }
}
