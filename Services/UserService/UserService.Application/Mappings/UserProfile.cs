﻿using AutoMapper;
using UserService.Application.DTO.Requests;
using UserService.Application.DTO.Responses;
using UserService.Domain.Entities;

namespace UserService.Api.App.Mappings
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