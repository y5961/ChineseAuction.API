using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Card
    {
        [Key]
        public int IdCard { get; set; }
        public int IdGift { get; set; }
        public int IdBuyer { get; set; }
        public int Price { get; set; }
    }
}
