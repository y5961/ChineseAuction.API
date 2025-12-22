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
            try
            {
                var gift=await _context.Gifts.FindAsync(giftId);
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
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error adding/updating gift {GiftId} in order {OrderId}", giftId, orderId);
                throw new Exception($"שגיאה בהוספה/עדכון מתנה עם מזהה {giftId} בהזמנה עם מזהה {orderId}", ex);
            }
        }

        public Task<bool?> CompleteOrder(int orderId)
        {
            var order = _context.OrdersOrders.Find(orderId);
            if (order == null)
                return Task.FromResult<bool?>(null);
            order.IsStatusDraft = OrderStatus.Completed;
            _context.SaveChanges();
            return Task.FromResult<bool?>(true);
        }

        public async Task<Order> CreateDraftOrderAsync(int userId)
        {
            try
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
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error creating draft order for user {UserId}", userId);
                throw new Exception($"שגיאה ביצירת הזמנת טיוטה עבור משתמש עם מזהה {userId}", ex);
            }

        }

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            try
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
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error deleting gift {GiftId} from order {OrderId}", giftId, orderId);
                throw new Exception($"שגיאה במחיקת מתנה עם מזהה {giftId} מהזמנה עם מזהה {orderId}", ex);
            }

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
           return  await _context.OrdersOrders.Where(o => o.IdUser == userId).ToListAsync();
        }

        public async Task<Order?> GetDraftOrderByUserAsync(int userId)
        {
            try
            {
             return await _context.OrdersOrders
                    .Include(o => o.OrdersGift)
                    .ThenInclude(go => go.Gift)
                .FirstOrDefaultAsync(o=>o.IdUser==userId && o.IsStatusDraft==OrderStatus.Draft);
            }
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching draft order for user {UserId}", userId);
                throw new Exception($"שגיאה בשליפת הזמנת טיוטה עבור משתמש עם מזהה {userId}", ex);
            }
        }
    }
}
