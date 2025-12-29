using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;
using Microsoft.Extensions.Logging;

namespace ChineseAuctionAPI.Services
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepo _repository;
        private readonly ILogger<GiftService> _logger;
        private readonly IConfiguration _configuration;


        public GiftService(IGiftRepo repository, ILogger<GiftService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<Gift> CreateGiftAsync(GiftDTO dto)
        {
            try
            {
                _logger.LogInformation("מתחיל תהליך יצירת מתנה חדשה: {GiftName}", dto.Name);

                var gift = new Gift
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Amount = dto.Quantity,
                    Price = dto.Price,
                    Image = dto.Image,
                    CategoryId = dto.CategoryId,
                    IdDonor = dto.IdDonor,
                };

                var result = await _repository.AddAsync(gift);

                //_logger.LogInformation("המתנה '{GiftName}' נוצרה בהצלחה במערכת עם מזהה {GiftId}", dto.Name, result.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה קריטית בעת יצירת המתנה '{GiftName}' בשכבת השירות.", dto.Name);
                throw;
            }
        }

        public async Task<IEnumerable<Gift>> GetAllGiftsAsync()
        {
            try
            {
                _logger.LogInformation("שולף את רשימת כל המתנות מהמאגר.");
                var gifts = await _repository.GetAllAsync();

                _logger.LogInformation("נשלפו בהצלחה {Count} מתנות.", gifts.Count());
                return gifts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בעת ניסיון לשלוף את כל המתנות מהמערכת.");
                throw;
            }
        }

        public async Task<Gift?> GetGiftByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("מנסה לאתר מתנה עם מזהה: {Id}", id);
                var gift = await _repository.GetByIdAsync(id);

                if (gift == null)
                {
                    _logger.LogWarning("לא נמצאה מתנה התואמת למזהה {Id}.", id);
                }
                else
                {
                    _logger.LogInformation("מתנה מזהה {Id} נשלפה בהצלחה.", id);
                }

                return gift;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "אירעה שגיאה בעת שליפת פרטי מתנה עבור מזהה {Id}.", id);
                throw;
            }
        }

        public async Task<bool> DeleteGiftAsync(int id)
        {
            try
            {
                _logger.LogInformation("מבקש לבצע מחיקה למתנה מזהה {Id}.", id);
                var deleted = await _repository.DeleteAsync(id);

                if (deleted)
                {
                    _logger.LogInformation("המתנה עם מזהה {Id} נמחקה מהמערכת לצמיתות.", id);
                }
                else
                {
                    _logger.LogWarning("פעולת המחיקה נכשלה עבור מזהה {Id}. ייתכן שהמתנה אינה קיימת או שישנן תלויות המונעות מחיקה.", id);
                }

                return deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בלתי צפויה בתהליך מחיקת מתנה מזהה {Id}.", id);
                throw;
            }
        }
    }
}