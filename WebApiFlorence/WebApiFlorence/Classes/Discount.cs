using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class Discount
    {
        public int DiscountId { get; set; }

        [Required(ErrorMessage = "Discount Value is required")]
        public double DiscountValue { get; set; }
        public bool DiscountStatus { get; set; }


    }
}
