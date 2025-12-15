using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Buyer
    {
        [Key]
        public int IdBuyer { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

    }
}
