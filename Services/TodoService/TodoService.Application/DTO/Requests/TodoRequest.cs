namespace TodoService.Application.DTO.Requests
{
    public class TodoRequest
    {
        public string Title { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public Guid UserId { get; set; }
    }
}
