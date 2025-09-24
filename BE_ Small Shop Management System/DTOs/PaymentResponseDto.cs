namespace BE__Small_Shop_Management_System.DTOs
{
    public class PaymentResponseDto
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
    }
}
