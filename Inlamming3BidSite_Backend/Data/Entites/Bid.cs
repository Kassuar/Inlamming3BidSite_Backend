namespace Inlamming3BidSite_Backend.Data.Entites
{
    public class Bid
    { public int BidId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime Timestamp { get; set; }
       
        //Foregin keys
        public int ?UserId { get; set; }
        public int AuctionId { get; set; }

        // Navigation properties
        public Auction Auction { get; set; }

        public User User { get; set; }
    }
    
    
    
}
