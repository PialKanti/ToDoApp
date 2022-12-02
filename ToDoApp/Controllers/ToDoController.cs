using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Dtos;
using ToDoApp.Entities;
using ToDoApp.Enums;
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
        public async Task<IEnumerable<ToDoItem>> Get([FromQuery] SearchCriteria searchCriteria)
        {
            if(searchCriteria == null)
            {
                return new List<ToDoItem>();
            }
            
            return await _repository.SearchByCriteria(searchCriteria);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoItemCreateDto dtoModel)
        {
            ToDoItem item = _mapper.Map<ToDoItem>(dtoModel);
            item.CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow);
            if(item.CreatedTimestamp <= 0)
            {
                return new ObjectResult(new { StatusCode = HttpStatusCode.InternalServerError, Message = "CreatedTimestamp must be greater than zero" });
            }
            await _repository.Insert(item);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToDoItemUpdateDto dtoModel)
        {
            if (id != dtoModel.Id)
            {
                return new BadRequestResult();
            }

            ToDoItem item = _mapper.Map<ToDoItem>(dtoModel);
            await _repository.Update(item);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
