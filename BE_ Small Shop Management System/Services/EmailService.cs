using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendVerificationEmailAsync(string toEmail, string code, string verificationLink)
    {
        var smtpServer = _configuration["EmailSettings:SmtpServer"];
        var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
        var senderEmail = _configuration["EmailSettings:SenderEmail"];
        var senderName = _configuration["EmailSettings:SenderName"];
        var userName = _configuration["EmailSettings:UserName"];
        var password = _configuration["EmailSettings:Password"];
        var enableSsl = bool.Parse(_configuration["EmailSettings:EnableSsl"]);

        using var client = new SmtpClient(smtpServer, smtpPort)
        {
            Credentials = new NetworkCredential(userName, password),
            EnableSsl = enableSsl
        };

        var subject = "Xác minh email đăng ký tài khoản";
        var body = $@"
            <h2>Xin chào,</h2>
            <p>Cảm ơn bạn đã đăng ký tài khoản.</p>
            <p>Mã xác minh của bạn là: <b>{code}</b></p>
            <p>Bạn cũng có thể nhấn vào link sau để xác thực:</p>
            <a href='{verificationLink}'>Xác minh email</a>
            <p><i>Mã có hiệu lực trong 10 phút.</i></p>
        ";

        var mailMessage = new MailMessage
        {
            From = new MailAddress(senderEmail, senderName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);

        await client.SendMailAsync(mailMessage);
    }
}
