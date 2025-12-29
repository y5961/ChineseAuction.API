using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly SaleContextDB _context;


        public OrderRepo(SaleContextDB context)
        {
            _context = context;

        }

        public async Task AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount)
        {
            var gift = await _context.Gifts.FindAsync(giftId);
            var order = await _context.OrdersOrders
                .Include(o => o.OrdersGift)
                .FirstOrDefaultAsync(o => o.IdOrder == orderId);

            if (order == null)
                throw new Exception("Order not found");

            var orderGift = order.OrdersGift
                .FirstOrDefault(go => go.IdGift == giftId);

            if (orderGift != null)
            {
                // Update existing gift amount
                orderGift.Amount = amount;
                _context.OrdersGift.Update(orderGift);
            }
            else
            {
                // Add new gift to order
                orderGift = new OrdersGift
                {
                    IdOrder = orderId,
                    IdGift = giftId,
                    Amount = amount,
                };
                _context.OrdersGift.Add(orderGift);
            }

            order.Price = order.Price + gift.Price * amount;
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> CompleteOrder(int orderId)
        {
            var order = await _context.OrdersOrders.FindAsync(orderId);
            if (order == null)
                return null;

            order.IsStatusDraft = OrderStatus.Completed;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> CreateDraftOrderAsync(int userId)
        {
            var draftOrder = new Order
            {
                IdUser = userId,
                IsStatusDraft = OrderStatus.Draft,
                OrderDate = DateTime.UtcNow,
                OrdersGift = new List<OrdersGift>()
            };

            _context.OrdersOrders.Add(draftOrder);
            await _context.SaveChangesAsync();
            return draftOrder;
        }

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            var gift = await _context.Gifts.FindAsync(giftId);
            var order = await _context.OrdersOrders
                .Include(o => o.OrdersGift)
                .FirstOrDefaultAsync(o => o.IdOrder == orderId);

            if (order == null)
                throw new Exception("Order not found");

            var orderGift = order.OrdersGift
                .FirstOrDefault(go => go.IdGift == giftId);

            if (orderGift == null)
                throw new Exception("Gift not found in order");

            orderGift.Amount -= amount;
            order.Price = order.Price - gift.Price * amount;

            if (orderGift.Amount <= 0)
            {
                _context.OrdersGift.Remove(orderGift);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Order?> GetByIdWithGiftsAsync(int orderId)
        {
            return _context.OrdersOrders
                .Include(o => o.OrdersGift)
                .ThenInclude(go => go.Gift)
                .FirstOrDefaultAsync(o => o.IdOrder == orderId);
        }

        public async Task<IEnumerable<Order?>> GetAllOrder(int userId)
        {
            return await _context.OrdersOrders
                .Where(o => o.IdUser == userId)
                .ToListAsync();
        }

        public async Task<Order?> GetDraftOrderByUserAsync(int userId)
        {
            return await _context.OrdersOrders
                .Include(o => o.OrdersGift)
                .ThenInclude(go => go.Gift)
                .FirstOrDefaultAsync(o => o.IdUser == userId && o.IsStatusDraft == OrderStatus.Draft);
        }
    }
}