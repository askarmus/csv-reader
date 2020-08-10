using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SmartStore.Core;
using SmartStore.DataAccess;
using SmartStore.DataAccess.Entity;
using SmartStore.Model;
using System.Threading.Tasks;

namespace SmartStore.BusinessServices
{
    public interface IUserService
    {
        Task< LoginResponseModel> AuthenticateAsync(string userName , string ipAddress);
    }

    public class UserService : IUserService
    {
        private FleetContext _context;
        private readonly AppSettings _appSettings;
        private readonly UserManager<AppUser> _userManager;

        public UserService(FleetContext context, IOptions<AppSettings> appSettings, UserManager<AppUser> userManager)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        public async  Task<LoginResponseModel> AuthenticateAsync(string userName, string ipAddress)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var jwtToken = generateJwtToken(user);
            return new LoginResponseModel(user, jwtToken, string.Empty);
        }

        private string generateJwtToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

 
    }
}
