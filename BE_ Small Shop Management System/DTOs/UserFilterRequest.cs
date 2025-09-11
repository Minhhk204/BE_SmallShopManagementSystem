namespace BE__Small_Shop_Management_System.DTOs
{
    public class UserFilterRequest : PagedRequest
    {
        public bool? IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
    }
}
