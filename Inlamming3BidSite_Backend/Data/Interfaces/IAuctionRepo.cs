using Inlamming3BidSite_Backend.Data.Entites;

namespace Inlamming3BidSite_Backend.Data.Interfaces
{
    public interface IAuctionRepo
    {

       Auction CreateAuction(Auction auction);

       List<Auction> GetAllAuctions();

       Auction GetAuctionById(int id);

       void Save();






    }
}
