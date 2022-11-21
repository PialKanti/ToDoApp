using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private bool _disposed;
        private readonly ToDoContext _dbContext;

        public ToDoRepository(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoItem> Insert(ToDoItem entity)
        {
            var valueTask = await _dbContext.ToDoItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        public async void Update(ToDoItem entityToUpdate)
        {
            _dbContext.ToDoItems.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Delete(await Get(id));
            return await _dbContext.SaveChangesAsync();
        }

        private void Delete(ToDoItem entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbContext.ToDoItems.Attach(entityToDelete);
            }

            _dbContext.ToDoItems.Remove(entityToDelete);
        }

        public async Task<ToDoItem> Get(int id)
        {
            return await _dbContext.ToDoItems.FindAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            return await _dbContext.ToDoItems.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
