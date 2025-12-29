using System.Linq;
using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;
using Microsoft.EntityFrameworkCore;

public class DonorRepository : IDonorRepository
{
    private readonly SaleContextDB _context;
   


    public DonorRepository(SaleContextDB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Donor>> GetAllAsync()
    {
        return await _context.Donors.ToListAsync();
    }

    public async Task<Donor?> GetByIdAsync(int id)
    {
        return await _context.Donors.FindAsync(id);
    }

    public async Task<int> AddAsync(Donor donor)
    {
        _context.Donors.Add(donor);
        await _context.SaveChangesAsync();
        return donor.IdDonor;
    }

    public async Task UpdateAsync(Donor donor)
    {
        _context.Entry(donor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var donor = await _context.Donors.FindAsync(id);
        if (donor != null)
        {
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Gift>>? GetGiftsAsync(int DonorId)
    {
        return await _context.Gifts.Where(go=>go.IdDonor== DonorId).Include(c=>c.Category).ToListAsync();
    }
}