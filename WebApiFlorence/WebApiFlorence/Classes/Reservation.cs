using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiFlorence.Classes;

namespace WebApiFlorence
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public double? NrPeople { get; set; }
        public DateTime? DateEvent { get; set; }
        public int StatusReservation { get; set; }
        public string? NotesFoodMenu{ get; set; }
        public string? NotesDrinksMenu { get; set; }
        public bool ? hasInvitation { get; set; }
        public int UserId { get; set; }
        public int? PaymentId { get; set; }
        public int? FoodMenuId { get; set; }
        public int? DrinksMenuId { get; set; }
        public int? DiscountId { get; set; }

    }
}
