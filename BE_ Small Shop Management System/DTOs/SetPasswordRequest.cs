namespace BE__Small_Shop_Management_System.DTOs
{
    public class SetPasswordRequest
    {
        public string? CurrentPassword { get; set; }  // có thể null nếu là reset từ admin
        public string NewPassword { get; set; } = string.Empty;
    }
}
