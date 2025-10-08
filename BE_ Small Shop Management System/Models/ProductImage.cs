namespace BE__Small_Shop_Management_System.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;

        // Quan hệ
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
