namespace BE__Small_Shop_Management_System.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; } = false;

        // Liên kết với User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
