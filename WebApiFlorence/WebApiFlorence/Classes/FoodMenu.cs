using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class FoodMenu
    {
        [Key]
        public int FoodMenuId { get; set; }
        public string FoodMenuName { get; set; }
        public double FoodMenuPrice { get; set; }
        public string FoodMenuDescription { get; set; }
    }
}
