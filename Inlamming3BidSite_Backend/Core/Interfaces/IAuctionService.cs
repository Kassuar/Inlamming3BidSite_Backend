using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.DTO;

namespace Inlamming3BidSite_Backend.Core.Interfaces
{
    public interface IAuctionService
    {
        Auction CreateAuction(AuctionDTO auctionDTO);

        List<Auction> GetAllAuctions();

        List <Auction> SearchAuction(string title);


    }
}
