namespace BE__Small_Shop_Management_System.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}
