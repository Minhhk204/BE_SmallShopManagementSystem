namespace BE__Small_Shop_Management_System.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }

        // Quan hệ
        public User User { get; set; } = null!;
        public Payment Payment { get; set; }   // add this if missing

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
