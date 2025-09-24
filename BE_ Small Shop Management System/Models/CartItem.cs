namespace BE__Small_Shop_Management_System.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Quan hệ
        public User User { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
