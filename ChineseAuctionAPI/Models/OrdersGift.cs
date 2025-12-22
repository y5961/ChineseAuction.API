using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class OrdersGift
    {
        [Key]

        public int IdOrdersGift { get; set; }
        public int IdGift { get; set; }
        public Gift Gift { get; set; } = null!;
        public int IdOrder { get; set; }
        public Order Order { get; set; } = null!;
        public int Amount { get; set; }
    }
}
