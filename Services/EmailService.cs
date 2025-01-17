using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        // Create the SMTP client
        var smtpClient = new SmtpClient
        {
            Host = _configuration["Smtp:Host"],
            Port = int.Parse(_configuration["Smtp:Port"]),
            Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
            EnableSsl = false  // Disable SSL for MailHog
        };

        // Create the email message
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["Smtp:FromEmail"]),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(to);

        // Send the email asynchronously
        await smtpClient.SendMailAsync(mailMessage);
    }
}
