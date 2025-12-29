using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.DTOs
{
    public class WinnerDTO
    {
        [Required]
        public string GiftName { get; set; } 
        [Required]
        public string WinnerFullName { get; set; } 
        [Required]
        [EmailAddress(ErrorMessage = "כתובת האימייל אינה תקינה")]
        public string WinnerEmail { get; set; } 
    }

}
