using System.Text.Json.Serialization;

namespace BE__Small_Shop_Management_System.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public List<string> RoleName { get; set; } = new();   // Admin, Customer,...
    }
}
