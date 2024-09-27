using Common.Database;

namespace UserService.Entities;

public class User : BaseEntity
{
    public string Nickname { get; set; } = string.Empty;
}
