using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ChineseAuctionAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _OrderRepository;
        private readonly ILogger<OrderService> _logger;
        private readonly IConfiguration _config;

        public OrderService(IOrderRepo OrderRepository, IConfiguration config, ILogger<OrderService> logger)
        {
            _OrderRepository = OrderRepository;
            _logger = logger;
            _config = config;
        }

        public async Task<bool> AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount)
        {
            try
            {
                _logger.LogInformation("מעדכן/מוסיף מתנה {GiftId} להזמנה {OrderId} בכמות {Amount}.", giftId, orderId, amount);
                await _OrderRepository.AddOrUpdateGiftInOrderAsync(amount, orderId, giftId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בעת עדכון מתנה {GiftId} בהזמנה {OrderId}.", giftId, orderId);
                throw;
            }
        }

        public async Task<bool> CompleteOrder(int orderId)
        {
            try
            {
                _logger.LogInformation("מנסה לסגור (Complete) הזמנה שמספרה {OrderId}.", orderId);
                await _OrderRepository.CompleteOrder(orderId);
                _logger.LogInformation("הזמנה {OrderId} נסגרה בהצלחה.", orderId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "נכשלה סגירת הזמנה {OrderId}.", orderId);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            try
            {
                _logger.LogInformation("מוחק {Amount} יחידות של מתנה {GiftId} מהזמנה {OrderId}.", amount, giftId, orderId);
                var result = await _OrderRepository.DeleteAsync(orderId, giftId, amount);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה במחיקת מתנה מהזמנה {OrderId}.", orderId);
                throw;
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(int userId)
        {
            try
            {
                _logger.LogInformation("שולף את כל ההזמנות עבור משתמש {UserId}.", userId);
                var orders = await _OrderRepository.GetAllOrder(userId);

                var ordersDto = orders.Select(o => new OrderDTO
                {
                    IdUser = o.IdUser,
                    OrderDate = o.OrderDate,
                    IsStatusDraft = o.IsStatusDraft,
                    Amount = o.OrdersGift.Sum(og => og.Amount),
                    OrdersGifts = o.OrdersGift.Select(og => new OrdersGiftDTO
                    {
                        Name = og.Gift.Name,
                        Amount = og.Amount,
                        Price = og.Gift.Price,
                        Description = og.Gift.Description,
                        Image = og.Gift.Image
                    }).ToList()
                });

                return ordersDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת הזמנות למשתמש {UserId}.", userId);
                throw;
            }
        }

        public async Task<OrderDTO?> GetByIdWithGiftsAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("שולף פרטי הזמנה {OrderId} כולל פירוט מתנות.", orderId);
                var order = await _OrderRepository.GetByIdWithGiftsAsync(orderId);

                if (order == null)
                {
                    _logger.LogWarning("הזמנה {OrderId} לא נמצאה.", orderId);
                    return null;
                }

                return new OrderDTO
                {
                    OrderDate = order.OrderDate,
                    IsStatusDraft = order.IsStatusDraft,
                    OrdersGifts = order.OrdersGift.Select(og => new OrdersGiftDTO
                    {
                        Name = og.Gift.Name,
                        Description = og.Gift.Description,
                        Category = og.Gift.Category,
                        Amount = og.Amount,
                        Price = og.Gift.Price,
                        Image = og.Gift.Image
                    }).ToList(),
                    TotalAmount = order.OrdersGift.Sum(og => og.Amount),
                    TotalPrice = order.OrdersGift.Sum(og => og.Amount * og.Gift.Price)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת הזמנה {OrderId} עם מתנות.", orderId);
                throw;
            }
        }

        public async Task<OrderDTO?> GetDraftOrderByUserAsync(int userId)
        {
            try
            {
                _logger.LogInformation("מחפש הזמנה במצב טיוטה (Draft) עבור משתמש {UserId}.", userId);
                var order = await _OrderRepository.GetDraftOrderByUserAsync(userId);

                if (order == null) return null;

                return new OrderDTO
                {
                    IdUser = order.IdUser,
                    OrderDate = order.OrderDate,
                    IsStatusDraft = order.IsStatusDraft,
                    OrdersGifts = order.OrdersGift.Select(og => new OrdersGiftDTO
                    {
                        Name = og.Gift.Name,
                        Amount = og.Amount,
                        Price = og.Gift.Price,
                        Description = og.Gift.Description,
                        Image = og.Gift.Image
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת טיוטת הזמנה למשתמש {UserId}.", userId);
                throw;
            }
        }
    }
}