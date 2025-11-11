namespace BE__Small_Shop_Management_System.Models
{
    public class SystemLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public User? User { get; set; }

        public string Method { get; set; } = "";   // GET, POST, PUT, DELETE
        public string Path { get; set; } = "";      
        public int StatusCode { get; set; }                 

        public string? Action { get; set; } = "";              
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Data { get; set; }
        public double Duration { get; set; }
        public string ApplicationName { get; set; } = "Small Shop System";
    }

}
