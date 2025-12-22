using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public enum OrderStatus
    {
        Draft,
        Completed,
    }

    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public ICollection<OrdersPackage> OrdersPackage { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus IsStatusDraft { get; set; } = OrderStatus.Draft;
        public ICollection <OrdersGift> OrdersGift { get; set; }
        public int Price { get; set; } = 1;

    }
}
