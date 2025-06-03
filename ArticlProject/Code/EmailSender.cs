using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace ArticlProject.Code
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ahmednabilsayed29@gmail.com", "kaxaghnoanpdcfui"),
                EnableSsl = true,
            };

            return smtpClient.SendMailAsync("ahmednabilsayed29@gmail.com", email, subject, htmlMessage);
        }
    }
}
