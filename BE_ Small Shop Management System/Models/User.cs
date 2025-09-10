namespace BE__Small_Shop_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }

        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        
        public bool IsDeleted { get; set; } = false;
        public  ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
