namespace Inlamming3BidSite_Backend.DTO
{
    public class BidsDTO

    {
        public int AuctionId { get; set; }

        public int UserId { get; set; }

        public decimal BidAmount { get; set; }

        public string Item { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public DateTime TimeStamp { get; set; }

    }
}
