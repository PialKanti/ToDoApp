using ToDoApp.Enums;
using ToDoApp.Models;

namespace ToDoApp.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        Task Update(T entityToUpdate);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> SearchByCriteria(SearchCriteria criteria);
    }
}
