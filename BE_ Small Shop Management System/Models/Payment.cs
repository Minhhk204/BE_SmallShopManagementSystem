namespace BE__Small_Shop_Management_System.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public string Method { get; set; } = "FakeGateway";  // Giả lập/gateway
        public string Status { get; set; } = "Pending";      // Pending, Paid, Failed
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
