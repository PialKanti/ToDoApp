using ToDoApp.Models;

namespace ToDoApp.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            List<ToDoItem> items = new List<ToDoItem>();
            items.Add(new ToDoItem
            {
                Id = 1,
                Name = "Going to Dentist", 
                CreatedDate = new DateTime(2022, 11, 15)
            });
            items.Add(new ToDoItem
            {
                Id = 2,
                Name = "Watching football match",
                CreatedDate = new DateTime(2022, 11, 10)
            });
            items.Add(new ToDoItem
            {
                Id = 3,
                Name = "Meeting with boss",
                CreatedDate = new DateTime(2022, 11, 5)
            });

            return items;
        }

        public ToDoItem GetToDoItemById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ToDoItem item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
