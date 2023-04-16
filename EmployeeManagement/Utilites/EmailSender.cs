using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace EmployeeManagement.Utilites
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = "employee.management.system.ems@gmail.com";
            var pw = "eemmss123456789";

            var client = new SmtpClient("smtp.gmail.com", 465)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(
                    from: mail,
                    to: email,
                    subject, 
                    htmlMessage));
        }
    }
}
