using ChineseAuctionAPI.DTOs;

public interface IDonorService
{
    Task<IEnumerable<DonorDTO>> GetAllDonorsAsync();
    Task<DonorDTO> GetDonorByIdAsync(int id);
    Task<int> CreateDonorAsync(DonorCreateDTO donorDto);
    Task UpdateDonorAsync(int id, DonorCreateDTO donorDto);
    Task DeleteDonorAsync(int id);
    Task<IEnumerable<GiftDTO>>? GetGiftsAsync(int donorId);
}