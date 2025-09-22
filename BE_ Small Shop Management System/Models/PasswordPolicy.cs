namespace BE__Small_Shop_Management_System.Models
{
    public class PasswordPolicy
    {
        public int RequiredLength { get; set; } = 8;
        public bool RequireUppercase { get; set; } = true;
        public bool RequireLowercase { get; set; } = true;
        public bool RequireDigit { get; set; } = true;
        public bool RequireNonAlphanumeric { get; set; } = true;
    }
}
