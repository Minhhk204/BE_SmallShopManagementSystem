using BE__Small_Shop_Management_System.DataContext;
using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Models;
using BE__Small_Shop_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly VNPayService _vnPayService;

        public PaymentController(AppDbContext context, VNPayService vnPayService)
        {
            _context = context;
            _vnPayService = vnPayService;
        }

        [HttpPost("checkout-vnpay")]
        public async Task<IActionResult> CheckoutVNPay()
        {
            var userId = GetUserIdFromClaims();
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
                return BadRequest(new { message = "Giỏ hàng trống" });

            var total = cartItems.Sum(c => c.Product.Price * c.Quantity);

            // Tạo Order
            var order = new Order
            {
                UserId = userId,
                TotalAmount = total,
                Status = "Pending",
                OrderDate = DateTime.UtcNow
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Tạo Payment
            var payment = new Payment
            {
                OrderId = order.Id,
                Method = "VNPay",
                Status = "Pending"
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            // Build VNPay URL
            var paymentUrl = _vnPayService.CreatePaymentUrl(order, HttpContext);
            return Ok(new { url = paymentUrl });
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> VNPayReturn()
        {
            var query = HttpContext.Request.Query;
            var vnp_ResponseCode = query["vnp_ResponseCode"].ToString();
            var orderId = int.Parse(query["vnp_TxnRef"]);

            var order = await _context.Orders.Include(o => o.Payment)
                                             .FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null) return NotFound();

            if (vnp_ResponseCode == "00") // thanh toán thành công
            {
                order.Status = "Paid";
                order.Payment.Status = "Paid";
            }
            else
            {
                order.Status = "Failed";
                order.Payment.Status = "Failed";
            }

            await _context.SaveChangesAsync();

            var response = new PaymentResponseDto
            {
                OrderId = order.Id,
                OrderStatus = order.Status,
                PaymentStatus = order.Payment.Status
            };

            return Ok(response);
        }


        private int GetUserIdFromClaims()
        {
            return int.Parse(User.FindFirst("UserId")?.Value ?? "0");
        }
    }

}
