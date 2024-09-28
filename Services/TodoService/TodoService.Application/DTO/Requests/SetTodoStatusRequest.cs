using TodoService.Domain.Entities;

namespace TodoService.Application.DTO.Requests;

public class SetTodoStatusRequest
{
    public Guid Id { get; set; }
    public TodoStatus Status { get; set; }
}
