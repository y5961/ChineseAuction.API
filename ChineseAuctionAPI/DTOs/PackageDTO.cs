namespace ChineseAuctionAPI.DTOs
{
    public class PackageDTO
    {
        public int IdPackage { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AmountRegular { get; set; }
        public int? AmountPremium { get; set; }
        public int Price { get; set; }
        public List<CardDTO> Cards { get; set; } = new();
    }

    public class CardDTO
    {
        public int IdCard { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
