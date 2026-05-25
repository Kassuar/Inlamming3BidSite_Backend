using Inlamming3BidSite_Backend.Data.Entites;

namespace Inlamming3BidSite_Backend.Data.Interfaces
{
    public interface IUserRepo
    {
       User CreateUser(User user);

       User GetUserByEmail(string email);





    }
}
