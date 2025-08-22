namespace BE__Small_Shop_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; } = true;   // Khóa/mở tài khoản
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Quan hệ
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
