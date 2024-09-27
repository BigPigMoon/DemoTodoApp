using AutoMapper;
using TodoService.Application.DTO.Requests;
using TodoService.Application.DTO.Responses;
using TodoService.Domain.Entities;

namespace TodoService.Application.Mappings;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<TodoRequest, Todo>();
        CreateMap<Todo, TodoResponse>();
    }
}
