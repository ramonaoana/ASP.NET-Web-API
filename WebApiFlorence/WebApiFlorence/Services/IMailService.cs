using WebApiFlorence.Classes;

namespace WebApiFlorence.Services
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
    }
}
