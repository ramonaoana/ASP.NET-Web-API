using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
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
            message.To.Add(mail.ToEmail);
            mailService.SendMailToUser(message);
            mail.AttachmentName = null;
            mail.Attachment = null;
            _context.MailRequest.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.MailRequestId }, mail);

        }

        [HttpPost("sendMailToAll")]
        public async Task<IActionResult> SendMailToAll(SimpleMail simpleMail)
        {
            MailMessage message = new MailMessage();
            MailRequest mail = new MailRequest();
            message.Subject = simpleMail.Subject;
            message.Body = simpleMail.Body;

            mail.Subject = simpleMail.Subject;
            mail.Body = simpleMail.Body;
            mail.Attachment = null;
            mail.AttachmentName = null;

            var queryUsersEmails = (from user in _context.Users
                                    where user.IsSubscribed.Equals(true)
                                    select user.Email).ToList();

            string addresses = "";
            
            foreach (var item in queryUsersEmails)
            {
                message.To.Add(item);
                addresses += item + ";";
            }
            addresses.Remove(addresses.Length - 1,1);
            mail.ToEmail = addresses;
            mailService.SendMailToUser(message);
            _context.MailRequest.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.MailRequestId }, mail);

        }


        [HttpPost("sendContractOnMail/{reservationId}")]
        public async Task<IActionResult> SendContractOnMail(int reservationId)
        {
            MailMessage message = new MailMessage();
            MailRequest mail = new MailRequest();
            message.Subject = "Confirmare Rezervare";
            message.Body = "Va multumim pentru rezervarea efectuata! Curand veti fi contactat de administratorul restaurantului pentru a stabili ultimele detalii.";


            var queryUser = (from reservation in _context.Reservations
                            join users in _context.Users on reservation.UserId equals users.UserId
                            where reservation.ReservationId == reservationId
                            select users.Email).FirstOrDefault();

            message.To.Add(queryUser);

            var queryDoc = (from reservation in _context.Reservations
                            join documents in _context.Documents on reservation.DocumentId equals documents.DocumentId
                            where reservation.ReservationId == reservationId
                            select documents.ContentDocument).FirstOrDefault();


            //byte[] bytes = Encoding.ASCII.GetBytes("FLORENCE");
            string date = DateTime.Now.ToString("dd_MM_yyyy");
            String name = "ContractFlorence_" + date+".pdf";
            mail.AttachmentName = name;
            mail.Attachment = queryDoc;
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.ToEmail = queryUser;
            //Attachment att = new Attachment(new MemoryStream(queryDoc), name);

            message.BodyEncoding = Encoding.UTF8;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(queryDoc);

            // Create the attachment from a stream. Be sure to name the data with a file and
            message.Attachments.Add(new Attachment(ms, name, "application/pdf"));

            mailService.SendMailToUser(message);

            _context.MailRequest.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.MailRequestId }, mail);
        }

    }
}
