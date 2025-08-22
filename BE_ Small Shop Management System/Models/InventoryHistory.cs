namespace BE__Small_Shop_Management_System.Models
{
    public class InventoryHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int QuantityChanged { get; set; }   // nhập hàng + / xuất hàng -
        public string Action { get; set; } = null!; // "Import", "UpdateStock"...
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
