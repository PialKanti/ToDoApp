using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Repositories;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController()
        {
            _repository = new ToDoRepository();
        }

        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return _repository.GetToDoItems();
        }
    }
}
