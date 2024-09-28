using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoService.Application.DTO.Requests;
using TodoService.Application.DTO.Responses;
using TodoService.Application.Interfaces.Services;
using TodoService.Domain.Entities;

namespace TodoService.Api.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController(IMapper mapper, ITodosService todosService) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ITodosService _todosService = todosService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoResponse>>> GetAllTodosAsync(CancellationToken cancellationToken = default)
    {
        var todos = await _todosService.GetAllTodosAsync(cancellationToken);

        return Ok(_mapper.Map<IEnumerable<TodoResponse>>(todos));
    }

    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<TodoResponse>>> GetUserTodosAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var todos = await _todosService.GetUserTodosAsync(userId, cancellationToken);
            var result = _mapper.Map<IEnumerable<TodoResponse>>(todos);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("by-status")]
    public async Task<ActionResult<IEnumerable<TodoResponse>>> GetTodosByStatusAsync(TodoStatus status, CancellationToken cancellationToken = default)
    {
        var todos = await _todosService.GetTodosByStatusAsync(status, cancellationToken);
        var result = _mapper.Map<IEnumerable<TodoResponse>>(todos);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TodoResponse>> CreateTodoAsync(CreateTodoRequest item, CancellationToken cancellationToken = default)
    {
        try
        {
            var todo = await _todosService.CreateTodoAsync(_mapper.Map<Todo>(item), cancellationToken);
            var result = _mapper.Map<TodoResponse>(todo);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("set-status")]
    public async Task<ActionResult<TodoResponse>> SetTodoStatus(SetTodoStatusRequest item, CancellationToken cancellationToken = default)
    {
        try
        {
            var todo = await _todosService.SetTodoStatusAsync(item.Id, item.Status, cancellationToken);
            var result = _mapper.Map<TodoResponse>(todo);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<TodoResponse>> UpdateTodoAsync(UpdateTodoRequest item, CancellationToken cancellationToken = default)
    {
        try
        {
            var newTodo = _mapper.Map<Todo>(item);
            var todo = await _todosService.UpdateTodoAsync(newTodo, cancellationToken);
            var result = _mapper.Map<TodoResponse>(todo);

            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTodoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            await _todosService.DeleteTodoAsync(id, cancellationToken);

            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
