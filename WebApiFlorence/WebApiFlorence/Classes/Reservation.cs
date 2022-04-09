using WebApiFlorence.Classes;

namespace WebApiFlorence
{
    public class Reservation
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public Payment? Payment { get; set; }
        public FoodMenu? FoodMenu { get; set; }
        public DrinksMenu? DrinksMenu { get; set; }
        public Discount? Discount { get; set; }
        public double NrPeople { get; set; }
        public DateTime DateEvent { get; set; }
        public int StatusReservation { get; set; }
        public string NotesFoodMenu{ get; set; }
        public string NotesDrinksMenu { get; set; }
    }
}
