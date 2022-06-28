using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public int MenuTypeEvent { get; set; }
        public string MenuName { get; set; }
        public double MenuPrice { get; set; }
        public string MenuDescription { get; set; }
        public int FoodMenuId { get; set; }
        public int DrinksMenuId { get; set; }
    }
}
