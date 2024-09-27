using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.DTO.Requests;
using UserService.DTO.Responses;
using UserService.Entities;
using UserService.Services;

namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UsersService usersService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsersAsync()
    {
        var users = await usersService.GetUsersAsync();

        return Ok(mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUserAsync(UserRequest dto)
    {
        var user = await usersService.CreateNewUserAsync(mapper.Map<User>(dto));

        return Ok(mapper.Map<UserResponse>(user));
    }
}
