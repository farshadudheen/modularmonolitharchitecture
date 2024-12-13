using DemoApp.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace DemoApp.Infrastructure.ExternalServices
{
    public class EmailServiceClient
    {
        private readonly EmailSettings _settings;

        public EmailServiceClient(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            using var smtpClient = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new System.Net.NetworkCredential(_settings.SenderEmail, _settings.SenderPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage(_settings.SenderEmail, recipientEmail, subject, body);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
