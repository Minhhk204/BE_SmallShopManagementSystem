namespace BE__Small_Shop_Management_System.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        // danh sách sản phẩm trong order
        public List<OrderItemDto> Items { get; set; }
    }
}
