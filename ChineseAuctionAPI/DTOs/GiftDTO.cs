namespace ChineseAuctionAPI.DTOs
{
    public class GiftDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }
        public int IdDonor { get; set; }
        public int Price { get; set; }
    }
}
