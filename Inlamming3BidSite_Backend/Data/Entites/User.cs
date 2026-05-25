namespace Inlamming3BidSite_Backend.Data.Entites
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Auction> Auctions { get; set; } = new List<Auction>();

        public List<Bid> Bids { get; set; }= new List<Bid>();





    }
}
