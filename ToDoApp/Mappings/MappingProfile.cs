using AutoMapper;
using ToDoApp.Dtos;
using ToDoApp.Entities;

namespace ToDoApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItemCreateDto, ToDoItem>();
        }
    }
}
