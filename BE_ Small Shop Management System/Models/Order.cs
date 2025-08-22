namespace BE__Small_Shop_Management_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "New"; // New → Processing → Completed

        public decimal TotalAmount { get; set; }

        // Quan hệ
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public Payment? Payment { get; set; }
    }
}
