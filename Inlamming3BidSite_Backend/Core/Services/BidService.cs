using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;
using Inlamming3BidSite_Backend.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;

namespace Inlamming3BidSite_Backend.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IAuctionRepo _auctionRepo;
        private readonly IBidRepo _bidRepo;

        public BidService(IAuctionRepo auctionRepo, IBidRepo bidRepo)
        {
            _auctionRepo = auctionRepo;
            _bidRepo = bidRepo;
        }
        public Bid CreateBid(BidsDTO bidsDTO)
        {
            var auction = _auctionRepo.GetAuctionById(bidsDTO.AuctionTitle);

            try
            {
                if (auction == null)
                {
                    throw new Exception("Auction not found.");
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            try
            {

                if (auction.UserId == bidsDTO.UserId)
                {
                    throw new Exception("You cannot bid on your own auction.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {


                if (auction.CurrentPrice >= bidsDTO.BidAmount)
                {
                    throw new Exception("Bid amount must be higher than the current price.");
                }


            }


            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {

                if (auction.EndTime <= DateTime.UtcNow)
                {
                    throw new Exception("Auction has already ended.");
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            var bid = new Bid
            {
                BidAmount = bidsDTO.BidAmount,
                Timestamp = DateTime.Now,
                UserId = bidsDTO.UserId,
                AuctionId = bidsDTO.AuctionTitle
            };

            return bid;



        }

        public List<Bid> GetAllBidsForAuction(int AuctionId)
        {
            return _bidRepo.GetAllBidsForAuction(AuctionId);
        }
    }
}

