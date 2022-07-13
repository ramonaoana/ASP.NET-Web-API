using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence.Classes
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string OwnerName { get; set; }
        public int MemberType { get; set; }
        public string? MemberONRCCode { get; set; }
        public string? MemberUniqueCode { get; set; }
        public string NumberPhone { get; set; }
        public string Addresse { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public byte[] MemberPictureData { get; set; }

    }
}
