using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;
using Inlamming3BidSite_Backend.DTO;

namespace Inlamming3BidSite_Backend.Core.Services
{
    public class AuctionService : IAuctionService
    {

        private readonly IAuctionRepo _auctionRepo;

        public AuctionService(IAuctionRepo auctionRepo)
        {
            _auctionRepo = auctionRepo;
        }

        public Auction CreateAuction(AuctionDTO auctionDTO)
        {   
            
           var auction= new Auction
           {
            Title= auctionDTO.Title,
            Item = auctionDTO.Item,
            StartTime = auctionDTO.StartTime,
            EndTime = auctionDTO.EndTime,
            CurrentPrice = auctionDTO.CurrentPrice
           };

            return _auctionRepo.CreateAuction(auction);
        }

        public List<Auction> GetAllAuctions()
        {
            return _auctionRepo.GetAllAuctions()
                .Where(a =>a.EndTime > DateTime.Now)
                .ToList();
        }


        

        
        List<Auction> IAuctionService.SearchAuction(string title)
        {

         return _auctionRepo.GetAllAuctions()
        .Where(a => a.EndTime > DateTime.Now && a.Title.ToLower()
        .Contains(title.ToLower()))
        .ToList();

        }
        

        

    }

}
