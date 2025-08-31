namespace BE__Small_Shop_Management_System.DTOs
{
    public class PermissionResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;      // "Users.View"
        public string Module { get; set; } = string.Empty;    // "Users"
        public string Description { get; set; } = string.Empty;
        public bool Granted { get; set; }
    }
}
