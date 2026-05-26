using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlamming3BidSite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            bidService = _bidService;
        }

        [HttpPost("Bid")]

        public IActionResult CreateBid( BidsDTO bidsDTO)
        {
            var bid =_bidService.CreateBid(bidsDTO);

            return Ok(bid);
        }

        [HttpGet("{auctionId}")]
        public IActionResult GetAllBidsForAuction(int auctionId)
        {
            var bids = _bidService.GetAllBidsForAuction(auctionId);

            if (!bids.Any())
            {
                return Ok(
                    "No bids found");
            }

            return Ok(bids);


        }
    }
}
