namespace BE__Small_Shop_Management_System.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string Module { get; set; }           // <— thêm
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Quan hệ N-N với Role (thông qua RolePermission)
        public ICollection<RolePermission> RolePermissions { get; set; }

        // Quan hệ N-N với User (thông qua UserPermission)
        public ICollection<UserPermission> UserPermissions { get; set; }
        
    }
}
