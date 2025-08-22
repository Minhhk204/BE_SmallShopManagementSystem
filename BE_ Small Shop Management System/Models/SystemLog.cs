namespace BE__Small_Shop_Management_System.Models
{
    public class SystemLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }  // Có thể null (nếu là action hệ thống)
        public User? User { get; set; }

        public string Action { get; set; } = null!;   // "Create Product", "Login", "Update Order"...
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Data { get; set; } // JSON mô tả dữ liệu
    }
}
