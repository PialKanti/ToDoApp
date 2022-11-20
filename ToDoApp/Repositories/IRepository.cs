namespace ToDoApp.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}
