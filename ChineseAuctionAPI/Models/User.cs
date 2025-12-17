using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public enum Role
    {
        User,
        Manager,
    }
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Role IsManager { get; set; } = Role.User;
        public ICollection<Order> Orders { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
