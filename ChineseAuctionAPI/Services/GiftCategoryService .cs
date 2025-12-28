namespace ChineseAuctionAPI.Services
{
    using ChineseAuctionAPI.DTOs;
    using ChineseAuctionAPI.Models;
    using ChineseAuctionAPI.Repositories;

    public class GiftCategoryService : IGiftCategoryService
    {
        private readonly IGiftCategoryRepo _repository;

        public GiftCategoryService(IGiftCategoryRepo repository)
        {
            _repository = repository;
        }

        public async Task<List<GiftCategoryDTO>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(c => new GiftCategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public async Task<GiftCategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return null;

            return new GiftCategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<GiftCategoryDTO> CreateAsync(CreateGiftCategoryDTO dto)
        {
            var category = new GiftCategory
            {
                Name = dto.Name
            };

            await _repository.CreateAsync(category);

            return new GiftCategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateGiftCategoryDTO dto)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;

            category.Name = dto.Name;
            await _repository.UpdateAsync(category);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;

            await _repository.DeleteAsync(category);
            return true;
        }
    }

}
