namespace Inlamming3BidSite_Backend.DTO
{
    public class AuctionDTO
    {

        public string Title { get; set; }
        public string Item { get; set; }= string .Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal CurrentPrice { get; set; }

       




    }
}
