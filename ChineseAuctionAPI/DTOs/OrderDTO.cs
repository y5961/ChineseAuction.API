using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.DTOs
{
    public class OrderDTO
    {
        public int IdUser { get; set; }
        public int Amount { get; set; } = 1;
        public DateTime OrderDate { get; set; }
        public OrderStatus IsStatusDraft { get; set; } = OrderStatus.Draft;
        public List<OrderItemDTO> OrderOne { get; set; } = new();
    }
    public class OrderItemDTO
    {
        public string Name { get; set; }
        public int Amount { get; set; } = 1;
        public int Price { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }

    }

}

