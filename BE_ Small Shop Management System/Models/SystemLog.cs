namespace BE__Small_Shop_Management_System.Models
{
    public class SystemLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public User? User { get; set; }

        public string Method { get; set; } = "";   // GET, POST, PUT, DELETE
        public string Path { get; set; } = "";      // /api/SystemLogs/paged
        public int StatusCode { get; set; }                  // 200, 400, 401, 500

        public string? Action { get; set; } = "";                // Ví dụ: "Cập nhật User"
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Data { get; set; }
        public double Duration { get; set; }
        public string ApplicationName { get; set; } = "Small Shop System";
    }

}
