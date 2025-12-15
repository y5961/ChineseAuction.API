using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Data
{
    public class SaleContextDB:DbContext
    {
        public SaleContextDB(DbContextOptions<SaleContextDB> options) : base(options) { }
        public DbSet<Buyer> Buyers => Set<Buyer>();
        public DbSet<Gift> Gifts => Set<Gift>();
        public  DbSet<Donor> Donors => Set<Donor>();
        public DbSet<OrdersGift> Orders => Set<OrdersGift>();
        public DbSet<Package> Packages => Set<Package>();
        public DbSet<Winner> winners => Set<Winner>();

    }
}
