namespace BE__Small_Shop_Management_System.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; } = string.Empty; // 👈 thêm UserName
        public List<OrderItemDto> Items { get; set; } = new();
    }
    public class OrderHistoryDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public List<OrderHistoryItemDto> Items { get; set; } = new();
    }

   
}
