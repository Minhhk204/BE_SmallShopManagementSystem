namespace BE__Small_Shop_Management_System.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }   // Ví dụ: "CreateProduct", "DeleteUser", "ViewReport"...

        // Quan hệ N-N với Role (thông qua RolePermission)
        public ICollection<RolePermission> RolePermissions { get; set; }

        // Quan hệ N-N với User (thông qua UserPermission)
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
