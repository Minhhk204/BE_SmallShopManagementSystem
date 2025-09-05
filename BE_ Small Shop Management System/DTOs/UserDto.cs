namespace BE__Small_Shop_Management_System.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        //public string Role { get; set; }   // Admin, Customer,...
    }
}
