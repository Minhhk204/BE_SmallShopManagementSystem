namespace BE__Small_Shop_Management_System.DTOs
{
    public class VerifyEmailDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class ForgotPasswordDto
    {
        public string Email { get; set; }
    }

    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
