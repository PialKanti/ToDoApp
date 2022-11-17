using ToDoApp.Models;

namespace ToDoApp.Repositories
{
    public interface IToDoRepository : IDisposable
    {
        IEnumerable<ToDoItem> GetToDoItems();
        ToDoItem GetToDoItemById(int id);
        bool Insert(ToDoItem item);
        bool Update(ToDoItem item);
        int Delete(int id);
    }
}
