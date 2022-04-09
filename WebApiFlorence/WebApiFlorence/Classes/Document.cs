namespace WebApiFlorence
{
    public class Document
    {
        public int Id { get; set; }
        public Template? Template { get; set; }
        public User? User { get; set; }
        public DateTime SigningDate { get; set; }
        public byte[]? ContentDocument { get; set; }
    }
}
