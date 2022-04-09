namespace WebApiFlorence.Classes
{
    public class Payment
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public double AmountPayment { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
