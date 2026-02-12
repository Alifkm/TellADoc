using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TellADoc.API.Identity
{
    public class TokenGenerator
    {
        public string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "INI_RAHASIA_BOS_JANGAN_SAMPE_KETAUAN"u8.ToArray();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, email),
                new(JwtRegisteredClaimNames.Email, email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = "TellADoc.API",
                Audience = "TellADoc.API",
                SigningCredentials = 
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
