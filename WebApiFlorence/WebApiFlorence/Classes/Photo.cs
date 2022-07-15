namespace WebApiFlorence.Classes
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public byte[] PhotoPictureData { get; set; }
        public int RestaurantId { get; set; }
    }
}
