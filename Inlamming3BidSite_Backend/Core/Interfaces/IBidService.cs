using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.DTO;

namespace Inlamming3BidSite_Backend.Core.Interfaces
{
    public interface IBidService
    {
        Bid CreateBid( BidsDTO bidsDTO);

        List <Bid> GetAllBidsForAuction(int AuctionId);
    }
}
