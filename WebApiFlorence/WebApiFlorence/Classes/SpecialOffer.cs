namespace WebApiFlorence.Classes
{
    public class SpecialOffer
    {
        public int Id { get; set; }
        public FoodMenu ? FoodMenu { get; set; }
        public DrinksMenu? DrinksMenu { get; set; }

        public double PriceOffer { get; set; }

        public string DescriptionOffer { get; set; }

        public DateTime StartDateOffer { get; set; }

        public DateTime EndDateOffer { get; set; }

    }
}
