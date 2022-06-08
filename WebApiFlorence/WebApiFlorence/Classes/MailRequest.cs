namespace WebApiFlorence.Classes
{
    public class MailRequest
    {
        public int MailRequestId { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
