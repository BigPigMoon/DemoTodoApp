namespace Common.Database;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
