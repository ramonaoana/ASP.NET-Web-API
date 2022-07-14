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

        [HttpGet("{id}")]
        public async Task<ActionResult<MailRequest>> GetMail(int id)
        {
            var mail = await _context.MailRequest.FindAsync(id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail;
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

        [HttpPost("sendMail")]
        public async Task<IActionResult> SendMailTo(MailRequest mail)
        {
            MailMessage message = new MailMessage();
            message.Subject = mail.Subject;
            message.Body =mail.Body;
            string[] addresses = mail.ToEmail.Split(',');
            foreach(var item in addresses)
            {
                message.To.Add(item);
            }
            mailService.SendMailToUser(message);
            _context.MailRequest.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.MailRequestId }, mail);

        }
    }
}
