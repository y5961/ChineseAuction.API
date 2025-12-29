using ChineseAuctionAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Manager")]
public class DonorsController : ControllerBase
{
    private readonly IDonorService _service;
    private readonly ILogger<DonorsController> _logger;

    public DonorsController(IDonorService service, ILogger<DonorsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DonorDTO>>> GetAll()
    {
        try
        {
            _logger.LogInformation("Fetching all donors");
            var donors = await _service.GetAllDonorsAsync();
            return Ok(donors);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching all donors");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DonorDTO>> Get(int id)
    {
        try
        {
            _logger.LogInformation("Fetching donor with ID: {Id}", id);
            var donor = await _service.GetDonorByIdAsync(id);
            if (donor == null)
            {
                _logger.LogWarning("Donor with ID: {Id} not found", id);
                return NotFound();
            }
            return Ok(donor);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching donor with ID: {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(DonorCreateDTO dto)
    {
        try
        {
            _logger.LogInformation("Creating a new donor");
            var id = await _service.CreateDonorAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating a donor");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DonorCreateDTO dto)
    {
        try
        {
            _logger.LogInformation("Updating donor with ID: {Id}", id);
            await _service.UpdateDonorAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating donor with ID: {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            _logger.LogInformation("Deleting donor with ID: {Id}", id);
            await _service.DeleteDonorAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting donor with ID: {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}