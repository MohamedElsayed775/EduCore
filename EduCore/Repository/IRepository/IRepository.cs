namespace EduCore.Repository.IRepository
{
    public interface IRepository<T>
    {
        List<T> ShowAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        int SaveChanges();
    }
}
