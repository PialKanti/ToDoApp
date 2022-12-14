using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Dtos;
using ToDoApp.Entities;
using ToDoApp.Models;
using ToDoApp.Repositories;
using ToDoApp.Utils;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public ToDoController(ToDoContext dbContext, IMapper mapper)
        {
            _repository = new ToDoRepository(dbContext);
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get([FromQuery] SearchCriteria searchCriteria)
        {
            return Ok(await _repository.SearchByCriteria(searchCriteria));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create([FromBody]ToDoItemCreateDto dtoModel)
        {
            ToDoItem item = _mapper.Map<ToDoItem>(dtoModel);

            item.CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow);
            if(item.CreatedTimestamp <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "CreatedTimestamp must be greater than zero");
            }
            
            return Ok(await _repository.Insert(item));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, ToDoItemUpdateDto dtoModel)
        {
            if (id < 0 && id != dtoModel.Id)
            {
                return BadRequest();
            }

            ToDoItem item = _mapper.Map<ToDoItem>(dtoModel);
            await _repository.Update(item);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ToDoItem item = await _repository.Delete(id);
            if (item == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
