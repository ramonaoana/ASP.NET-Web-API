using System.ComponentModel.DataAnnotations;

namespace WebApiFlorence
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [StringLength(14)]
        public string? CNP { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        public bool Rights { get; set; }

        public bool IsConfirmed { get; set; }

        public byte[]? PictureData { get; set; }
    }
}
