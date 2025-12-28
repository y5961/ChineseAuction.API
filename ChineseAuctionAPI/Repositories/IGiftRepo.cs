using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Repositories
{
    public interface IGiftRepo
    {
        Task<IEnumerable<Gift>> GetAllAsync();
        Task<Gift?> GetByIdAsync(int id);
        Task<Gift> AddAsync(Gift gift);
        Task<bool> UpdateAsync(Gift gift);
        Task<bool> DeleteAsync(int id);

    }
}
