using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence
{
    public class Document
    {
        public int DocumentId { get; set; }
        [Required(ErrorMessage = "Signing Date is required")]
        public DateTime SigningDate { get; set; }
        public byte[]? ContentDocument { get; set; }
        public int ReservationId { get; set; }
    }
}
