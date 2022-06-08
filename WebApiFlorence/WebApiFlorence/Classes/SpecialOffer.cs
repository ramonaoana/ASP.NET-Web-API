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
        public int FoodMenuId { get; set; }
        public int DrinksMenuId { get; set; }

    }
}
