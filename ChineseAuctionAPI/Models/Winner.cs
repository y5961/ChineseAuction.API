using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Winner
    {
        [Key]

        public int IdWinner { get; set; }
        public int IdBuyer { get; set; }
        public int IdGift { get; set; }


    }
}
