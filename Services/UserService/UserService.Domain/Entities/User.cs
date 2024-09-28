using Common.Database;

namespace UserService.Domain.Entities;

public class User : BaseEntity
{
    public string Nickname { get; set; } = string.Empty;
}
