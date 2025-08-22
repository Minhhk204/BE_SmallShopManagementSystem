namespace BE__Small_Shop_Management_System.DTOs
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }   // có thể hash sau khi nhận
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
