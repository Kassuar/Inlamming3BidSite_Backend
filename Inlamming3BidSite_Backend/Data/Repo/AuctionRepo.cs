using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;

namespace Inlamming3BidSite_Backend.Data.Repo
{
    public class AuctionRepo : IAuctionRepo
    {
        private readonly AppDbContext _context;

        public AuctionRepo(AppDbContext context)
        {
            _context = context;
        }

        public Auction CreateAuction(Auction auction)
        {
            _context.Auctions.Add(auction);
            _context.SaveChanges();
            return auction;
        }

        public List<Auction> GetAllAuctions() 
        
        {
            return _context.Auctions.ToList();
        }

        public Auction GetAuctionById(int id)
        {
           return _context.Auctions.FirstOrDefault(a => a.AuctionId == id);
        }

        public List<Auction> SearchAuctions(string keyword)
        {
            return _context.Auctions
                .Where(a => a.Item.Contains(keyword))
                .ToList();
        }
    }
}
