using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoService.Application.DTO.Requests;
using TodoService.Application.DTO.Responses;
using TodoService.Application.Interfaces.Services;
using TodoService.Domain.Entities;

namespace TodoService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("/by-user-id/{userId:guid}")]
        public async Task<ActionResult<IEnumerable<TodoResponse>>> GetUserTodosAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            try
            {
                var todos = await _todosService.GetUserTodosAsync(userId, cancellationToken);

                return Ok(_mapper.Map<TodoResponse>(todos));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/by-status")]
        public async Task<ActionResult<IEnumerable<TodoResponse>>> GetTodosByStatusAsync(TodoStatus status, CancellationToken cancellationToken = default)
        {
            var todos = await _todosService.GetTodosByStatusAsync(status, cancellationToken);

            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult<TodoResponse>> CreateTodoAsync(TodoRequest item, CancellationToken cancellationToken = default)
        {
            try
            {
                var todo = await _todosService.CreateTodoAsync(_mapper.Map<Todo>(item), cancellationToken);

                return _mapper.Map<TodoResponse>(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/id:guid")]
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
}
