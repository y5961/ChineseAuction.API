

    using global::ChineseAuctionAPI.DTOs;
    using global::ChineseAuctionAPI.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace ChineseAuctionAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class OrdersController : ControllerBase
        {
            private readonly IOrderService _orderService;

            public OrdersController(IOrderService orderService)
            {
                _orderService = orderService;
            }

            // GET: api/orders/user/5
            [HttpGet("user/{userId}")]
            public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll(int userId)
            {
                var orders = await _orderService.GetAllAsync(userId);
                return Ok(orders);
            }

            // GET: api/orders/5
            [HttpGet("{orderId}")]
            public async Task<ActionResult<OrderDTO>> GetById(int orderId)
            {
                var order = await _orderService.GetByIdWithGiftsAsync(orderId);
                if (order == null) return NotFound();
                return Ok(order);
            }

            // GET: api/orders/draft/5
            [HttpGet("draft/{userId}")]
            public async Task<ActionResult<OrderDTO>> GetDraft(int userId)
            {
                var draft = await _orderService.GetDraftOrderByUserAsync(userId);
                if (draft == null) return NotFound();
                return Ok(draft);
            }

            // POST: api/orders/add-gift
            [HttpPost("add-gift")]
            public async Task<ActionResult> AddOrUpdateGift([FromQuery] int orderId, [FromQuery] int giftId, [FromQuery] int amount)
            {
                var result = await _orderService.AddOrUpdateGiftInOrderAsync(orderId, giftId, amount);
                if (result) return Ok();
                return BadRequest();
            }

            // DELETE: api/orders/delete-gift
            [HttpDelete("delete-gift")]
            public async Task<ActionResult> DeleteGift([FromQuery] int orderId, [FromQuery] int giftId, [FromQuery] int amount)
            {
                var result = await _orderService.DeleteAsync(orderId, giftId, amount);
                if (result) return Ok();
                return BadRequest();
            }

            // POST: api/orders/complete/5
            [HttpPost("complete/{orderId}")]
            public async Task<ActionResult> CompleteOrder(int orderId)
            {
                var result = await _orderService.CompleteOrder(orderId);
                if (result) return Ok();
                return BadRequest();
            }
        }
    }


