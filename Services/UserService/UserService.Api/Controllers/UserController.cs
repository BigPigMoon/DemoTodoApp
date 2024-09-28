using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTO.Requests;
using UserService.Application.DTO.Responses;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUsersService usersService, IMapper mapper) : ControllerBase
{
    private readonly IUsersService _usersService = usersService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsersAsync()
    {
        var users = await _usersService.GetUsersAsync();

        return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _usersService.GetUserAsync(id, cancellationToken);

            return Ok(_mapper.Map<UserResponse>(user));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUserAsync(UserRequest dto)
    {
        var user = await _usersService.CreateNewUserAsync(_mapper.Map<User>(dto));

        return Ok(_mapper.Map<UserResponse>(user));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _usersService.DeleteUserAsync(id, cancellationToken);

        return Ok();
    }
}
