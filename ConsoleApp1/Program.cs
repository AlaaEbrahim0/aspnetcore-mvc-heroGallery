using System.Net.Mail;
using FluentEmail.Smtp;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory()
            }); ;
        }
    }
}