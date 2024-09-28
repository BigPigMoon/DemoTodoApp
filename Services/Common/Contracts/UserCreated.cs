namespace Common.Contracts;

public interface UserCreated
{
    Guid Id { get; set; }
    string Nickname { get; set; }
    DateTime CreatedAt { get; set; }
}
