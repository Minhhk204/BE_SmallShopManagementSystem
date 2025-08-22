namespace BE__Small_Shop_Management_System.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int? SellerId { get; set; }
    }
}
