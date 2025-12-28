using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.DTOs
{
    public class OrderDTO
    {
        public int TotalAmount { get; set; }
        public int TotalPrice { get; set; }
        public int IdUser { get; set; }
        public int Amount { get; set; } = 1;
        public DateTime OrderDate { get; set; }
        public OrderStatus IsStatusDraft { get; set; } = OrderStatus.Draft;
        public List<OrdersGiftDTO> OrdersGifts { get; set; } = new();
    }
    public class OrdersGiftDTO
    {
        public GiftCategory Category { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; } = 1;
        public int Price { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }


    }

}

