namespace BE__Small_Shop_Management_System.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserCount { get; set; }
    }
    public class CreateRoleDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
