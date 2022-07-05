namespace WebApiFlorence.Classes
{
    public class ReservationDetails
    {
        public int DocumentNumber { get; set; }
        public String DocumentDate { get; set; }
        public String currentDate { get; set; }
        public String ReservationNrPeople{ get; set; }
        public String ReservationDate{ get; set; }
        public String ReservationTypeEvent{ get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Town { get; set; }
        public string Addresse { get; set; }
        public string County { get; set; }
        public string CNP { get; set; }
        public String MenuName { get; set; }
        public Double MenuPrice { get; set; }
        public String FoodMenuName { get; set; }
        public Double FoodMenuPrice { get; set; }
        public String FirstDish { get; set; }
        public String FirstDishProducts { get; set; }
        public String SecondDish { get; set; }
        public String SecondDishProducts { get; set; }
        public String ThirdDish { get; set; }
        public String ThirdDishProducts { get; set; }
        public String FourthDish { get; set; }
        public String FourthDishProducts { get; set; }
        public String DrinksMenuName { get; set; }
        public Double DrinksMenuPrice { get; set; }
        public String DrinksMenuProducts { get; set; }
        public Double TotalPrice { get; set; }
        public Double Advance { get; set; }
        public Double AmountPackages { get; set; }

    }
}
