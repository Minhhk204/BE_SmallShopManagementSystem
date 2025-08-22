namespace BE__Small_Shop_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }   // tồn kho
        public string? ImageUrl { get; set; }

        public int SellerId { get; set; }  // Người bán tạo
        public User Seller { get; set; } = null!;

        // Quan hệ
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
