using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.DTO;

namespace Inlamming3BidSite_Backend.Core.Interfaces
{
    public interface IUserService
    {
        User Register (UserDTO dto);

        string Login (LoginDTO loginDTO);
    }
}
