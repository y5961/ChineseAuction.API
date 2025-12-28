using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
  
    public class Gift
    {
        [Key]

        public int IdGift { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public GiftCategory Category { get; set; }
        public int Amount { get; set; } = 1;
        public string? Image { get; set; }
        public int IdDonor { get; set; }
        public Donor Donor { get; set; }
        public bool IsDrawn { get; set; } = false;
        public int Price { get; set; }
        public ICollection<OrdersGift> OrdersGifts { get; set; }
    }
}
