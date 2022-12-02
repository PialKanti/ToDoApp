using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        public async Task Create(ToDoItemCreateDto dtoModel)
        {
            ToDoItem item = _mapper.Map<ToDoItem>(dtoModel);
            item.CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow);
            await _repository.Insert(item);
        }

        [HttpPut("{id}")]
        public async Task<HttpResponseMessage> Update(int id, ToDoItemUpdateDto dtoModel)
        {
            if (id != dtoModel.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            ToDoItem item = _mapper.Map<ToDoItem>(dtoModel);
            await _repository.Update(item);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
