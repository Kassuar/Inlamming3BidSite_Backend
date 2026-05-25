using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;

namespace Inlamming3BidSite_Backend.Data.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
    

    public UserRepo(AppDbContext context)
        {
            _context = context;
        }
        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

  
    }

}
