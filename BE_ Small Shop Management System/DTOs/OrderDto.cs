namespace BE__Small_Shop_Management_System.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new();
    }
    
    public class UpdateOrderStatusDto
    {
        public string Status { get; set; } = null!;
    }


}
