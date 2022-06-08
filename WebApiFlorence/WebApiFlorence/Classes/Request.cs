using System.ComponentModel.DataAnnotations;
namespace WebApiFlorence
{
    public class Request
    {
        public int RequestId { get; set; }

        [StringLength(20)]
        public string TypeRequest { get; set; }

        [StringLength(20)]
        public string Description { get; set; }

        public bool StatusRequest { get; set; }

        public DateTime DateRequest { get; set; }   

        public int UserId { get; set; }
    }
}
