using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Repositories
{
    public class PackageRepo : IPackageRepo
    {
        private readonly SaleContextDB _context;
        public PackageRepo(SaleContextDB context) => _context = context;

        public async Task<IEnumerable<Package>> GetAllAsync() =>
            await _context.Packages.Include(p => p.Cards).ToListAsync();

        public async Task<Package?> GetByIdAsync(int id) =>
            await _context.Packages.Include(p => p.Cards)
                                   .FirstOrDefaultAsync(p => p.IdPackage == id);

        public async Task AddAsync(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Package package)
        {
            _context.Packages.Update(package);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync();
            }
        }
    }
}
