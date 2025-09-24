using BE__Small_Shop_Management_System.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BE__Small_Shop_Management_System.Services
{
    public class VNPayService
    {
        private readonly IConfiguration _config;

        public VNPayService(IConfiguration config)
        {
            _config = config;
        }

        public string CreatePaymentUrl(Order order, HttpContext context)
        {
            var vnpayData = new SortedList<string, string>();
            vnpayData.Add("vnp_Version", "2.1.0");
            vnpayData.Add("vnp_Command", "pay");
            vnpayData.Add("vnp_TmnCode", _config["VNPay:TmnCode"]);
            vnpayData.Add("vnp_Amount", ((int)(order.TotalAmount * 100)).ToString());
            vnpayData.Add("vnp_CreateDate", DateTime.UtcNow.ToString("yyyyMMddHHmmss"));
            vnpayData.Add("vnp_CurrCode", "VND");
            vnpayData.Add("vnp_IpAddr", context.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1");
            vnpayData.Add("vnp_Locale", "vn");
            vnpayData.Add("vnp_OrderInfo", $"Thanh toan don hang {order.Id}");
            vnpayData.Add("vnp_OrderType", "other");
            vnpayData.Add("vnp_ReturnUrl", _config["VNPay:ReturnUrl"]);
            vnpayData.Add("vnp_TxnRef", order.Id.ToString());

            var query = string.Join("&", vnpayData.Select(kvp => $"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value)}"));
            var signData = string.Join("&", vnpayData.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            var hashSecret = _config["VNPay:HashSecret"];
            var vnp_SecureHash = HmacSHA512(hashSecret, signData);

            return $"{_config["VNPay:BaseUrl"]}?{query}&vnp_SecureHash={vnp_SecureHash}";
        }

        private string HmacSHA512(string key, string input)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(input);
            using var hmac = new HMACSHA512(keyBytes);
            var hashBytes = hmac.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

}
