namespace WebApiFlorence.Classes
{
    public class SpecialOffer
    {
        public int SpecialOfferId { get; set; }

        public int SpecialOfferTypeEvent { get; set; }

        public double PriceOffer { get; set; }

        public string DescriptionOffer { get; set; }
        public DateTime StartDateOffer { get; set; }
        public DateTime EndDateOffer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MenuId { get; set; }

    }
}
