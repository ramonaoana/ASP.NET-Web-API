using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using WebApiFlorence.Classes;
using WebApiFlorence.Data;
using WebApiFlorence.Services;

namespace WebApiFlorence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly DataContext _context;

        public EmailController(IMailService mailService, DataContext context)
        {
            this.mailService = mailService;
            _context = context;

        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailRequest mailRequest)
        {
            try
            {

                await mailService.SendMailAsync(mailRequest);
                _context.MailRequest.Add(mailRequest);
                await _context.SaveChangesAsync();
  
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("sendMailToOneUser")]
        public async Task<IActionResult> SendMailTo()
        {
            MailMessage message = new MailMessage();
            message.Subject = "Notificare";
            message.Body = "Not";
            message.To.Add("ramonaoana29@gmail.com");
            mailService.SendMailToUser(message);
            return Ok();

        }
    }
}
