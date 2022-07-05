using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiFlorence.Classes;

namespace WebApiFlorence
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public double? NrPeople { get; set; }
        public double? ReservationAmount { get; set; }
        public DateTime? DateEvent { get; set; }
        public DateTime ReservationDate { get; set; }
        public int StatusReservation { get; set; }
        public int ReservationTypeEvent { get; set; }
        public bool ? hasInvitation { get; set; }
        public int UserId { get; set; }
        public int? PaymentId { get; set; }
        public int? MenuId { get; set; }
        public int? DiscountId { get; set; }
        public int? DocumentId { get; set; }

    }
}
