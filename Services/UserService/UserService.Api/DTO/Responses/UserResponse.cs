namespace UserService.DTO.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
