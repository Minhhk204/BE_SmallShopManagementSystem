namespace BE__Small_Shop_Management_System.DTOs
{
    public class SystemLogFilterRequest : PagedRequest
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Action { get; set; }
        public string? Method { get; set; }       // ✅ GET, POST, PUT, DELETE
        public int? StatusCode { get; set; }      // ✅ 200, 400, 401, 403, 500...
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double? MinDuration { get; set; }
        public double? MaxDuration { get; set; }

    }

}
