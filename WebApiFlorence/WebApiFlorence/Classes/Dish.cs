using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string DishName { get; set; }
        public double DishPrice { get; set; }
        public byte[]? DishPictureData { get; set; }
    }
}
