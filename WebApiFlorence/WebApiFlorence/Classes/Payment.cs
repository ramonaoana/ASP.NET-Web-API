namespace WebApiFlorence.Classes
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double AmountPayment { get; set; }
        public String CardNumber { get; set; }
        public String ExpirationDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
