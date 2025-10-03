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
        public int? CategoryId { get; set; }

        // Quan hệ
        public Category? Category { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<CartItem>? CartItems { get; set; }
       

    }
}
