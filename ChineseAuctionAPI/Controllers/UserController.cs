using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] DtoLogin dto)
        {
            var resp = await _userService.RegisterAsync(dto);
            return Ok(resp);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DtologinRequest dto)//Task<IActionResult>
        {
            var resp = await _userService.LoginAsync(dto.Email, dto.Password);
            return Ok(resp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetUserWithOrders(int id)
        {
            var userWithOrders = await _userService.GetUserWithOrdersAsync(id);
            if (userWithOrders == null)
            {
                return NotFound();
            }
            return Ok(userWithOrders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("UserController is working!");
        }
        

    }
}
