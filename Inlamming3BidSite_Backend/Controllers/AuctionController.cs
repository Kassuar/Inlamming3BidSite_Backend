using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlamming3BidSite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            auctionService = _auctionService;
        }

        [HttpPost("Create Auction")] 

        public IActionResult CreateAuction([FromBody] AuctionDTO auctionDTO)
        {
            var result = _auctionService.CreateAuction(auctionDTO);

            if(result == null)
            {
                return BadRequest("Failed tp create auction");
            }

            return Ok(result);
        }

        [HttpGet ("Acutions")] 

        public IActionResult GetAllAuctions()
        {
            var result= _auctionService.GetAllAuctions();

           
            return Ok (result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuctionById(int id)
        {
            var auction =
                _auctionService
                .GetAuctionById(id);

            if (auction == null)
            {
                return Ok("Auction not found");
            }

            return Ok(auction);
        }

        [HttpGet("Search")]
        public IActionResult SearchAuction(string title)
        {
            var auctions = _auctionService.SearchAuction(title);

            if (!auctions.Any())
            {
                return Ok("No auctions found");
            }

            return Ok(auctions);
        }


    }

}
