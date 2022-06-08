namespace WebApiFlorence.Classes
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Note { get; set; }
        public String? Feedback { get; set; }
        public int UserId { get; set; } 
        public DateTime ReviewDate { get; set; }
    }
}
