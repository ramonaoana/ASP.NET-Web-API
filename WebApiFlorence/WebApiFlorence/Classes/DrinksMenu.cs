using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class DrinksMenu
    {
        [Key]
        public int DrinksMenuId { get; set; }
        public string DrinksMenuName { get; set; }
        public double DrinksMenuPrice { get; set; }
        public byte[] DrinksMenuPictureData { get; set; }
    }
}
