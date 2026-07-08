using EduCore.Models;
using EduCore.Models.ViewModel;

namespace EduCore.Repository.IRepository
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        List<ResultsViewModel> GetResults(int traineeId);
    }
}
