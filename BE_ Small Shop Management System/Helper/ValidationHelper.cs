using System.Text.RegularExpressions;

namespace BE__Small_Shop_Management_System.Helper
{
    public static class ValidationHelper
    {
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            var regex = new Regex(@"^0\d{9}$");
            return regex.IsMatch(phone);
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
