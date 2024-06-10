using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using QuickMailer;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(EmailMessage emailMessage)
        {
            Email email = new();
            if (email.IsValidEmail(emailMessage.To))
            {
                return email.SendEmail(emailMessage.To, "", "", emailMessage.Subject, emailMessage.Body);
            }
            return false;
        }
    }
}
