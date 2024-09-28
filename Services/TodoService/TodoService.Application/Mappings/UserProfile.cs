using AutoMapper;
using Common.Contracts;
using TodoService.Domain.Entities;

namespace TodoService.Application.Mappings;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreated, User>();
    }
}
