using CoreBusiness.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookCartAPI.Auth
{
    [ExcludeFromCodeCoverage]
    public class JwtAuth : IJwtAuth
    {
        private readonly IUserService _userService;
       
        private readonly string secretKey;
        private readonly string tokenDurationMinutes;
    

        public JwtAuth(IUserService userService, IConfiguration config)
        {
            this._userService = userService;
            this.secretKey = config.GetSection("JWTConfig").GetSection("Secret").Value;
            this.tokenDurationMinutes = config.GetSection("JWTConfig").GetSection("TokenDurationMinutes").Value;
        }

        public async Task<TokenResponse> Authentication(string username, string password)
        {
            var userDetails =await _userService.GetUser(username, password);

            if (userDetails==null|| userDetails?.UserName!= username)
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(secretKey);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userDetails.UserName),
                        new Claim(ClaimTypes.Role, userDetails.Role)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(tokenDurationMinutes)),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            //return tokenHandler.WriteToken(token);
            return new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                ExpiryTime = token.ValidTo
            };
        }
    }
}
