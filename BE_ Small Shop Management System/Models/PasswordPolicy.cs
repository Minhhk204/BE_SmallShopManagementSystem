namespace BE__Small_Shop_Management_System.Models
{
    public class PasswordPolicy
    {
        public int Id { get; set; } // khóa chính
        public int RequiredLength { get; set; } = 8;
        public bool RequireUppercase { get; set; } = true;
        public bool RequireLowercase { get; set; } = true;
        public bool RequireDigit { get; set; } = true;
        public bool RequireNonAlphanumeric { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
