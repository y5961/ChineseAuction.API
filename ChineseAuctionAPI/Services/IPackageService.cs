using ChineseAuctionAPI.DTOs;
using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Services
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDTO>> GetAllAsync();
        Task<PackageDTO?> GetByIdAsync(int id);
        Task AddAsync(Package package);
        Task UpdateAsync(Package package);
        Task DeleteAsync(int id);
    }
}
