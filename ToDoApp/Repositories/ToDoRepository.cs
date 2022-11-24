using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Entities;

namespace ToDoApp.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _dbContext;

        public ToDoRepository(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoItem> Insert(ToDoItem entity)
        {
            var valueTask = _dbContext.ToDoItems.Add(entity);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        public async Task Update(ToDoItem entityToUpdate)
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
    }
}
