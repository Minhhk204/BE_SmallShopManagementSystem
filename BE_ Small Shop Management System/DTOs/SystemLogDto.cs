namespace BE__Small_Shop_Management_System.DTOs
{
    public class SystemLogDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string Action { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? Data { get; set; }
    }
}
