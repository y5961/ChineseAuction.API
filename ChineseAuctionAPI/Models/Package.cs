using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Package
    {
        [Key]

        public int IdPackage { get; set; }
        public int AmountRegular { get; set; }
        public int? AmountPremium { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
