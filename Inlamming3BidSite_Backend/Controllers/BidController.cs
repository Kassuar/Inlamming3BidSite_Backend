using Inlamming3BidSite_Backend.Core.Interfaces;
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

        [HttpPost ("Bid")]
    }
}
