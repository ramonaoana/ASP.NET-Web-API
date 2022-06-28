namespace WebApiFlorence.Classes
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public int MemberId { get; set; }
        public byte[]? PhotoPictureData { get; set; }
    }
}
