namespace WebApiFlorence.Classes
{
    public class MenuDetails
    {
        public Menu Menu { get; set; }
        public FoodMenu FoodMenu { get; set; }
        public DrinksMenu  DrinksMenu { get; set; }
        public List<Product> Drinks { get; set; }
        public List<DishDetails> Dishes { get; set; }
    }
}
