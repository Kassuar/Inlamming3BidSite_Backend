using Inlamming3BidSite_Backend.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Inlamming3BidSite_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Bid> Bids { get; set; }

    }
}
