using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TesteGol.Model.Repositories;
using System.Threading;
using System.Threading.Tasks;
using TesteGol.Model.Services;

namespace TesteGol.Infrastructure.Security
{
    public class AutheticationService : IAutheticationService
    {
        private readonly IUserRepository _userRepository;

        public AutheticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> Authenticate(string login, string password)
        {
            var user = await _userRepository.GetByLoginAndPassWord(login, password).ConfigureAwait(false);

            if(user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("O0OlZHO-C.d*~,t]J[+Iwm)~^PR>@%LFf23v_jU{AGvsi`Pvl)1QrK]|rB5?h@N");

            var createAt = DateTime.UtcNow;
            var expirationDate = createAt.AddDays(1);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login)
                }),
                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                NotBefore = createAt
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(new
            {
                Created = createAt.ToString("yyyy-MM-dd HH:mm:ss", Thread.CurrentThread.CurrentCulture),
                Expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss", Thread.CurrentThread.CurrentCulture),
                AccessToken = tokenHandler.WriteToken(token)
            }); ;
        }
    }
}
