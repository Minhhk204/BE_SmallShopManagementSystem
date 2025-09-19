namespace BE__Small_Shop_Management_System.DTOs
{
  
    public class SystemLogDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? UserId { get; set; }
        public string Method { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public string? Action { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Duration { get; set; }
        public string ApplicationName { get; set; } = "Small Shop System";
        public string? Data { get; set; }
    }

}
