namespace ToDoApp.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        Task Update(T entityToUpdate);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
