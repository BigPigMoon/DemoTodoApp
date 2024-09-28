namespace TodoService.Application.DTO.Requests;

public class UpdateTodoRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public Guid UserId { get; set; }
}
