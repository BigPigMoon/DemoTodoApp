using AutoMapper;
using UserService.DTO.Requests;
using UserService.DTO.Responses;
using UserService.Entities;

namespace UserService.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
