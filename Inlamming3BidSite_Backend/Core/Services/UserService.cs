using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.Data.Entites;
using Inlamming3BidSite_Backend.Data.Interfaces;
using Inlamming3BidSite_Backend.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Inlamming3BidSite_Backend.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

     

        public User Register(UserDTO dto)
        {
          var existingUser = _userRepo.GetUserByEmail(dto.Email);

          if (existingUser != null)
          {
              throw new Exception("User with this email already exists.");
          }

          var user = new User
          {
              Email = dto.Email,
              Password = dto.Password,
              Name = dto.UserName
          };
          return _userRepo.CreateUser(user);
        }

        string IUserService.Login(LoginDTO loginDTO)
        {
            var user = _userRepo.GetUserByEmail(loginDTO.Email);

            if (user == null || user.Password != loginDTO.Password)
                return null;

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mykey1234567&%%485734579453%&//1255362"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5021",
                audience: "http://localhost:5021",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
