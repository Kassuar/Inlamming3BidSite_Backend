using System.Globalization;

namespace Inlamming3BidSite_Backend.Data.Entites
{
    public class Auction
    {
        public int AuctionId { get; set; }

        public string Title { get; set; }
        public string Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal CurrentPrice { get; set; }


        //Foreign key
        public int UserId { get; set; }

        //Navigation props
        public User User { get; set; }

        //Connecting the Db tables
        public List<Bid> Bids { get; set; }=new List<Bid>();
        
         
    }
}
