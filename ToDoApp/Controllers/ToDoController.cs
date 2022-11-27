using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Entities;
using ToDoApp.Enums;
using ToDoApp.Repositories;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController(ToDoContext dbContext)
        {
            _repository = new ToDoRepository(dbContext);
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> Get([FromQuery] int type)
        {
            ToDoItemType itemType = (ToDoItemType)type;
            if (itemType != ToDoItemType.All)
            {
                return await _repository.GetAllByType(itemType);
            }

            return await _repository.GetAll();
        }

        [HttpPost]
        public async Task Create(ToDoItem item)
        {
            await _repository.Insert(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _repository.Update(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
