using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Donor
    {
        [Key]
        public int IdDonor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress] 
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

    }
}
