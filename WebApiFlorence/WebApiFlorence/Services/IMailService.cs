using System.Net.Mail;
using WebApiFlorence.Classes;

namespace WebApiFlorence.Services
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
        Task SendMailToUser(MailMessage message);
    }
}
