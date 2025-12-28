using System.Data;
using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BCrypt.Net;
using System.Runtime.ConstrainedExecution;

namespace ChineseAuctionAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository; 
        //private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _config;
           
        public UserService(IUserRepo userRepository, IConfiguration config)//, ILogger<UserService> logger
        {
            _userRepository = userRepository;
            //_logger = logger;
            _config = config;
        }
        //return new user dto
        public static UserDTO MapToUserDto(User u)
        {
            return new UserDTO
            {
                
                Identity = u.Identity,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            };
        }


        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users.Select(u => MapToUserDto(u)).ToList();
            }
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching all users");
                throw new Exception("שגיאה בשליפת רשימת המשתמשים", ex);
            }
        }
        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                return user != null ? MapToUserDto(user) : null;
            }
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error fetching user with ID {Id}", id);
                throw new Exception($"שגיאה בשליפת משתמש עם מזהה {id}", ex);
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _userRepository.DeleteAsync(id);

            }
            catch (Exception ex)
            {
                // Optional: Log the exception here if needed  
                throw new Exception($"Error deleting user with ID {id}", ex);
            }
        }
        public async Task<DtoUserOrder?> GetUserWithOrdersAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserWithOrdersAsync(userId);
                return new DtoUserOrder
                {
                   
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Orders = user.Orders?.Select(o => new OrderDTO
                    {
                        IsStatusDraft = o.IsStatusDraft,
                        OrderDate = o.OrderDate,
                        IdUser = o.IdUser,

                        OrdersGifts = o.OrdersGift.Select(ord => new OrdersGiftDTO
                        {
                            Name = ord.Gift.Name,
                            Amount = ord.Amount,
                            Price = ord.Gift.Price,
                            Description = ord.Gift.Description,
                            Image = ord.Gift.Image
                        }).ToList()
                    }).ToList() ?? new List<OrderDTO>()
                };
            }
            
            catch(Exception ex)
            {
                return null;
            }


        }


        public async Task<string?> RegisterAsync(DtoLogin dto)
        {
            try
            {
                if (dto == null) throw new ArgumentNullException(nameof(dto));
                if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                    return null;

                var email = dto.Email.Trim();

                if (await _userRepository.ExistEmailAsync(email))
                    return null;

                var hashed = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                var newUser = new User
                {
                    Identity = dto.Identity,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    PasswordHash = hashed,
                    Email = email,
                    PhoneNumber = dto.PhoneNumber,
                    City = dto.City,
                    Address = dto.Address,
                    Orders = new List<Order>(),
                    Cards = new List<Card>()
                };

                var created = await _userRepository.AddAsync(newUser);
                var token = GenerateJwtToken(created);

                return token;
            }
            catch (Exception ex)
            {
                // כאן מומלץ להוסיף רישום ללוג: _logger.LogError(ex, "Error registering new user");
                throw new Exception("שגיאה בהרשמת משתמש חדש", ex);

            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var u = await _userRepository.GetByEmailAsync(email.Trim());
            if (u == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(password, u.PasswordHash))
                return null;

            var token = GenerateJwtToken(u);

            return token;
        }


        private string GenerateJwtToken(User user)
        {
            var jwtSection = _config.GetSection("Jwt");
            var keyStr = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key is missing from configuration");

            // שימוש ב-SecurityKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
        new Claim(ClaimTypes.Role, user.IsManager.ToString())
        //new Claim("isManager", user.IsManager.ToString().ToLower()) 
    };

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60), // או מה-Config
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

 
}
