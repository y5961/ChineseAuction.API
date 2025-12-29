using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChineseAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        private readonly ILogger<GiftController> _logger;

        public GiftController(IGiftService giftService, ILogger<GiftController> logger)
        {
            _giftService = giftService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all gifts.");
                var gifts = await _giftService.GetAllGiftsAsync();
                return Ok(gifts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all gifts.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve gift with ID: {Id}", id);
                var gift = await _giftService.GetGiftByIdAsync(id);

                if (gift == null)
                {
                    _logger.LogWarning("Gift with ID: {Id} not found.", id);
                    return NotFound();
                }

                return Ok(gift);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching gift with ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GiftDTO dto)
        {
            try
            {
                _logger.LogInformation("Attempting to create a new gift.");
                var newGift = await _giftService.CreateGiftAsync(dto);
                _logger.LogInformation("Gift created successfully with ID: {Id}", newGift.IdGift);

                return CreatedAtAction(nameof(Get), new { id = newGift.IdGift }, newGift);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new gift.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to delete gift with ID: {Id}", id);
                var success = await _giftService.DeleteGiftAsync(id);

                if (!success)
                {
                    _logger.LogWarning("Delete failed. Gift with ID: {Id} not found.", id);
                    return NotFound();
                }

                _logger.LogInformation("Gift with ID: {Id} deleted successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting gift with ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}