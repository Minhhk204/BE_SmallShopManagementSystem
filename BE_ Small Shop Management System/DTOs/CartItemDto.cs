namespace BE__Small_Shop_Management_System.DTOs
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
