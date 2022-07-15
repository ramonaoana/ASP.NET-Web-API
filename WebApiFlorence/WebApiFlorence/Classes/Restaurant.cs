using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantType{ get; set; }
        public string OwnerName { get; set; }
        public string? RestaurantONRCCode { get; set; }
        public string? RestaurantUniqueCode { get; set; }
        public string NumberPhone { get; set; }
        public string Addresse { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public byte[] RestaurantPictureData { get; set; }

    }
}
