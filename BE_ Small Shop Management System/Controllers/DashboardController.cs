using BE__Small_Shop_Management_System.DTOs;
using BE__Small_Shop_Management_System.Helper;
using BE__Small_Shop_Management_System.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE__Small_Shop_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tổng quan nhanh (summary cards)
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            // Chỉ tính đơn hàng đã hoàn tất
            var completedOrders = _unitOfWork.OrderRepository.Query()
                .Where(o => o.Status == "Completed");

            var totalRevenue = await completedOrders
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var totalOrders = await completedOrders.CountAsync();
            var totalCustomers = await _unitOfWork.UserRepository.Query().CountAsync();
            var totalProducts = await _unitOfWork.ProductRepository.Query().CountAsync();

            var result = new
            {
                totalRevenue,
                totalOrders,
                totalCustomers,
                totalProducts
            };

            return Ok(ApiResponse<object>.SuccessResponse(result, "Lấy tổng quan dashboard thành công"));
        }

        // Biểu đồ tổng quan (theo thời gian)
        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview([FromQuery] string range = "month")
        {
            var now = DateTime.Now;
            var startDate = range switch
            {
                "year" => new DateTime(now.Year, 1, 1),
                "month" => new DateTime(now.Year, now.Month, 1),
                "week" => now.AddDays(-7),
                _ => now.AddMonths(-1)
            };

            // Chỉ tính đơn hàng đã hoàn tất
            var orders = await _unitOfWork.OrderRepository.Query()
                .Where(o => o.Status == "Completed" && o.OrderDate >= startDate)
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    TotalOrders = g.Count(),
                    TotalRevenue = g.Sum(x => x.TotalAmount)
                })
                .OrderBy(g => g.Date)
                .ToListAsync();

            var labels = orders.Select(o => o.Date.ToString("dd/MM")).ToList();
            var orderCounts = orders.Select(o => o.TotalOrders).ToList();
            var revenue = orders.Select(o => o.TotalRevenue).ToList();

            var result = new
            {
                labels,
                orders = orderCounts,
                revenue
            };

            return Ok(ApiResponse<object>.SuccessResponse(result, "Lấy dữ liệu biểu đồ tổng quan thành công"));
        }

        // Biểu đồ Doanh thu vs Chi phí
        [HttpGet("revenue-vs-cost")]
        public async Task<IActionResult> GetRevenueVsCost([FromQuery] string range = "month")
        {
            var now = DateTime.Now;
            var startDate = range switch
            {
                "year" => new DateTime(now.Year, 1, 1),
                "month" => new DateTime(now.Year, now.Month, 1),
                "week" => now.AddDays(-7),
                _ => now.AddMonths(-1)
            };

            // Chỉ tính đơn hàng đã hoàn tất
            var data = await _unitOfWork.OrderRepository.Query()
                .Where(o => o.Status == "Completed" && o.OrderDate >= startDate)
                .GroupBy(o => o.OrderDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Revenue = g.Sum(x => x.TotalAmount),
                    Cost = g.Sum(x => x.TotalAmount * 0.7m) // giả định chi phí 70%
                })
                .OrderBy(g => g.Month)
                .ToListAsync();

            var labels = data.Select(d => "Tháng " + d.Month).ToList();
            var revenue = data.Select(d => d.Revenue).ToList();
            var cost = data.Select(d => d.Cost).ToList();

            var result = new
            {
                labels,
                revenue,
                cost
            };

            return Ok(ApiResponse<object>.SuccessResponse(result, "Lấy dữ liệu biểu đồ doanh thu - chi phí thành công"));
        }

        // Top 5 sản phẩm bán chạy nhất (chỉ tính từ đơn đã hoàn tất)
        [HttpGet("top-products")]
        public async Task<IActionResult> GetTopProducts()
        {
            // Lấy ProductId từ OrderItem trong các Order hoàn tất
            var completedOrderIds = await _unitOfWork.OrderRepository.Query()
                .Where(o => o.Status == "Completed")
                .Select(o => o.Id)
                .ToListAsync();

            var topProductsData = await _unitOfWork.OrderItemRepository.Query()
                .Where(oi => completedOrderIds.Contains(oi.OrderId))
                .GroupBy(oi => oi.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    QuantitySold = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(5)
                .ToListAsync();

            var productIds = topProductsData.Select(x => x.ProductId).ToList();

            var products = await _unitOfWork.ProductRepository.Query()
                .Where(p => productIds.Contains(p.Id))
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Images,
                    p.Price,
                    p.Description,
                    p.CategoryId
                })
                .ToListAsync();

            var result = topProductsData
                .Join(products,
                    tp => tp.ProductId,
                    p => p.Id,
                    (tp, p) => new
                    {
                        ProductId = p.Id,
                        p.Name,
                        p.Images,
                        p.Price,
                        p.Description,
                        p.CategoryId,
                        QuantitySold = tp.QuantitySold,
                        TotalRevenue = tp.QuantitySold * p.Price
                    })
                .OrderByDescending(x => x.QuantitySold)
                .ToList();

            return Ok(ApiResponse<IEnumerable<object>>.SuccessResponse(result, "Lấy danh sách sản phẩm bán chạy thành công"));
        }

        // Tóm tắt đơn hàng theo trạng thái (giữ nguyên)
        [HttpGet("order-summary")]
        public async Task<IActionResult> GetOrderSummary()
        {
            var summary = await _unitOfWork.OrderRepository.Query()
                .GroupBy(o => o.Status)
                .Select(g => new OrderSummaryDto
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            return Ok(ApiResponse<List<OrderSummaryDto>>.SuccessResponse(summary, "Lấy tóm tắt đơn hàng thành công"));
        }
    }
}
