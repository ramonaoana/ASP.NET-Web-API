using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using WebApiFlorence.Classes;

namespace WebApiFlorence.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendMailAsync(MailRequest mailRequest)
        {
            var fromAddress = new MailAddress("restaurant.florence2022@gmail.com", "Restaurant Florence");
            var toAddress = new MailAddress(mailRequest.ToEmail);
            var fromPassword = "florence2022";
            var subject = mailRequest.Subject;
            var body = mailRequest.Body;
            var builder = new BodyBuilder();

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);


            }
        }
        public async Task SendMailToUser(MailMessage message)
        {
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            MailMessage mess = message;

            MailAddress fromAddress = new MailAddress("restaurant.florence2022@gmail.com", "Restaurant Florence");
            smtpClient.Host = "smtp-relay.sendinblue.com"; 
            smtpClient.Port = 587;

            NetworkCredential info = new NetworkCredential("restaurant.florence2022@gmail.com", "mZd3NPg0D2AEOwav");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = info;

            message.From = fromAddress;

            message.IsBodyHtml = false;
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
               
            }

        }

    }
}
