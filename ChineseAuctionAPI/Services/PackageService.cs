//using ChineseAuctionAPI.DTOs;
//using ChineseAuctionAPI.Models;
//using ChineseAuctionAPI.Repositories;

//namespace ChineseAuctionAPI.Services
//{
//    public class PackageService : IPackageService
//    {
//        private readonly IPackageRepo _packageRepo;

//        public PackageService(IPackageRepo packageRepo)
//        {
//            _packageRepo = packageRepo;
//        }

//        public async Task<IEnumerable<PackageDTO>> GetAllAsync()
//        {
//            var packages = await _packageRepo.GetAllAsync();
//            return packages.Select(p => new PackageDTO
//            {
//                IdPackage = p.IdPackage,
//                Name = p.Name,
//                Description = p.Description,
//                AmountRegular = p.AmountRegular,
//                AmountPremium = p.AmountPremium,
//                Price = p.Price,
//                Cards = p.Cards.Select(c => new CardDTO
//                {
//                    IdCard = c.IdCard,
//                    Name = c.Name,
//                    Description = c.Description
//                }).ToList()
//            });
//        }

//        public async Task<PackageDTO?> GetByIdAsync(int id)
//        {
//            var package = await _packageRepo.GetByIdAsync(id);
//            if (package == null) return null;
//            return new PackageDTO
//            {
//                IdPackage = package.IdPackage,
//                Name = package.Name,
//                Description = package.Description,
//                AmountRegular = package.AmountRegular,
//                AmountPremium = package.AmountPremium,
//                Price = package.Price,
//                Cards = package.Cards.Select(c => new CardDTO
//                {
//                    IdCard = c.IdCard,
//                    Name = c.Name,
//                    Description = c.Description
//                }).ToList()
//            };
//        }

//        public async Task AddAsync(Package package) => await _packageRepo.AddAsync(package);
//        public async Task UpdateAsync(Package package) => await _packageRepo.UpdateAsync(package);
//        public async Task DeleteAsync(int id) => await _packageRepo.DeleteAsync(id);
//    }
//}
