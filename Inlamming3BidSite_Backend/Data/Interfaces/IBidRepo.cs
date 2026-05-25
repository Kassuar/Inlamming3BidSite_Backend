using Inlamming3BidSite_Backend.Data.Entites;
using Microsoft.Identity.Client;

namespace Inlamming3BidSite_Backend.Data.Interfaces
{
    public interface IBidRepo
    {
        Bid CreateBid(Bid bid);

        List<Bid> GetAllBidsForAuction(int auctionId);


    }
}
