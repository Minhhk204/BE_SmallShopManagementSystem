namespace BE__Small_Shop_Management_System.Helper
{
    public static class EmailTemplateHelper
    {
        public static string GetRegisterBody(string code, string verificationLink)
        {
            return $@"
            <h2>Xin chào,</h2>
            <p>Cảm ơn bạn đã đăng ký tài khoản.</p>
            <p>Mã xác minh của bạn là: <b>{code}</b></p>
            <p>Hoặc nhấn vào link sau để xác minh:</p>
            <a href='{verificationLink}'>Xác minh email</a>
            <p><i>Mã có hiệu lực trong 10 phút.</i></p>
        ";
        }

        public static string GetForgotPasswordBody(string code, string resetLink)
        {
            return $@"
            <h2>Xin chào,</h2>
            <p>Bạn đã yêu cầu đặt lại mật khẩu cho tài khoản.</p>
            <p>Mã xác thực của bạn là: <b>{code}</b></p>
            <p>Hoặc nhấn vào liên kết sau để đặt lại mật khẩu:</p>
            <a href='{resetLink}'>Đặt lại mật khẩu</a>
            <p><i>Mã có hiệu lực trong 10 phút.</i></p>
        ";
        }
    }
}
