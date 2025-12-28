using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Repositories;

namespace ChineseAuctionAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _OrderRepository;
        //private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _config;

        public OrderService(IOrderRepo OrderRepository, IConfiguration config)//, ILogger<UserService> logger
        {
            _OrderRepository = OrderRepository;
            //_logger = logger;
            _config = config;
        }
        public async Task<bool> AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount)
        {
            try
            {
                await AddOrUpdateGiftInOrderAsync(amount, orderId, giftId);
                return true;
            }

            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching user with ID {Id}", id);
                throw new Exception("Error adding or updating gift in order", ex);
            }
        }

        public async Task<bool> CompleteOrder(int orderId)
        {
            try
            {
                await _OrderRepository.CompleteOrder(orderId);
                return true;

            }
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching user with ID {Id}", id);
                throw new Exception("Error completing order", ex);
            }
        }

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            try
            {
                return await _OrderRepository.DeleteAsync(orderId, giftId, amount);
            }
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching user with ID {Id}", id);
                throw new Exception("Error deleting gift from order", ex);
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(int userId)
        {
            try
            {
                var orders = await _OrderRepository.GetAllOrder(userId);
                var ordersDto = orders.Select(o => new OrderDTO
                {
                    IdUser = o.IdUser,
                    OrderDate = o.OrderDate,
                    IsStatusDraft = o.IsStatusDraft,

                    // אם Amount מייצג כמות מתנות:
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
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching user with ID {Id}", id);
                throw new Exception("Error fetching all orders for user", ex);
            }
        }

        public async Task<OrderDTO?> GetByIdWithGiftsAsync(int orderId)
        {
            try
            {
                var order = await _OrderRepository.GetByIdWithGiftsAsync(orderId);
                if (order == null)
                    return null;

                var orderDto = new OrderDTO
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

                return orderDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching order by ID with gifts", ex);
            }
        }


        public Task<OrderDTO?> GetDraftOrderByUserAsync(int userId)
        {
            try
            {
                return _OrderRepository.GetDraftOrderByUserAsync(userId)
                    .ContinueWith(task =>
                    {
                        var order = task.Result;
                        if (order == null)
                            return null;
                        var orderDto = new OrderDTO
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
                        return orderDto;
                    });
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching draft order for user", ex);
            }
        }

   
    }
}
