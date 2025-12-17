using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.DTOs
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }


    }
    public class DtoLogin
    {
        [Key]
       
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
