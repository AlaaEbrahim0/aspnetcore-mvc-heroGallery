using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Utilites
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration config;

        public EmailSender(IConfiguration config)
        {
            this.config = config;
        }
        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            
            var senderEmail = new MailAddress("employee.management.system.ems@gmail.com", "Employee Management System");
            var receiverEmail = new MailAddress(recipientEmail, "Receiver");

            var password = config["SenderEmailPass"];
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail.Address, password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            using var mail = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mail.Headers.Add("X-Unsubscribe-Web", "https://example.com/unsubscribe");
            mail.Headers.Add("X-Mailgun-Tag", "tag_name_here");
            await smtp.SendMailAsync(mail);
            
        }
        
    }

}
