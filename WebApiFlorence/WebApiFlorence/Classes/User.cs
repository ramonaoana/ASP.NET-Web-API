using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApiFlorence.Classes;

namespace WebApiFlorence
{
    [BindProperties]
    public class User
    {        
        public int UserId { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "County is required")]
        [StringLength(30, ErrorMessage = "Must be between 3 and 30 characters", MinimumLength = 3)]
        public string County { get; set; }

        [Required(ErrorMessage = "Town is required")]
        [StringLength(30, ErrorMessage = "Must be between 3 and 30 characters", MinimumLength = 3)]
        public string Town { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "This field must be 13 characters")]
        public string? CNP { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
        public string Phone { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Mail is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(25, ErrorMessage = "Must be between 6 and 25 characters", MinimumLength = 6)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Client's response is required")]
        public Boolean IsSubscribed { get; set; }

        public bool Rights { get; set; }

        public bool IsConfirmed { get; set; }

        

    }
}
