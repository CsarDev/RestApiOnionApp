namespace Domain.Repositories
{
    public interface IRepository<T> where T:class
    {

        IEnumerable<T> GetAll();
        T Get(Guid Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
