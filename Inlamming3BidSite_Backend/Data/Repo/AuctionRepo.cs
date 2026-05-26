using Inlamming3BidSite_Backend.Data;
using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;

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
        return _context.Auctions
            .FirstOrDefault(
            a => a.AuctionId == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}