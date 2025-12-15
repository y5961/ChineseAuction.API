using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Order
    {
        [Key]

        public int IdOrder { get; set; }
        public int IdBuyer { get; set; }
        public Buyer Buyer { get; set; }

        public int IdPackage { get; set; }
        public Package Package { get; set; }
        public int Amount { get; set; } = 1;
        public DateTime OrderDate { get; set; }

    }
}
