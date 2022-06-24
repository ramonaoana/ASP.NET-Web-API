namespace WebApiFlorence.Classes
{
    public class FoodMenu
    {
        public int FoodMenuId { get; set; }
        public int FoodMenuTypeEvent { get; set; }
        public string  FoodMenuName{ get; set; }

        public double FoodMenuPrice { get; set; }

        public string FoodMenuDescription { get; set; }

        public int FirstDishId { get; set; }
        public int SecondDishId { get; set; }
        public int ThirdDishId { get; set; }
        public int? FourthDishId { get; set; }
    }
}
