using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.DTOs
{
    public class UserDTO
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string Identity { get; internal set; }

    }
    public class DtoLogin
    {
        public string Password { get; set; }
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

    public class DtoUserOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderDTO> Orders { get; set; } = new();
    }
    public class DtoLoginResponse
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
    public class DtologinRequest
    {
        [EmailAddress,Required]
        public string Email { get; set; }
        [Required,MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
