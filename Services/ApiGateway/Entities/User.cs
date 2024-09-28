namespace ApiGateway.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<Todo> Todos { get; set; } = [];
}
