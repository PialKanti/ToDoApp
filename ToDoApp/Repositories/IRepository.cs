namespace ToDoApp.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        void Update(T entityToUpdate);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
