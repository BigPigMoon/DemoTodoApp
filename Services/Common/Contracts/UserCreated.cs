namespace Common.Contracts;

public record UserCreated
{
    public Guid Id { get; init; }
    public string Nickname { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}
