using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inlamming3BidSite_Backend.Data.Repo
{
    public class BidRepo : IBidRepo
    {
        private readonly AppDbContext _context;
        public BidRepo(AppDbContext context)
        {
            _context = context;
        }

        public Bid CreateBid(Bid bid)
        {
            _context.Bids.Add(bid);
            _context.SaveChanges();
            return bid;
        }

        public List<Bid> GetAllBidsForAuction(int auctionId)
        {
            return _context.Bids
                .Include(p => p.User)
                .Include(p => p.Auction)
                .Where(b => b.AuctionId == auctionId).ToList();
                
        }
    }
}
