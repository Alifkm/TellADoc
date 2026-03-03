using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TellADoc.API.Context;
using TellADoc.API.Models;

namespace TellADoc.API.Services
{
    public class AuthService
    {
        public IConfiguration Configuration { get; }

        public AuthService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateAccessToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);
            var issuer = Configuration["Jwt:Issuer"];
            var audience = Configuration["Jwt:Audience"];
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            byte[] randomBytes = new byte[64];
            RandomNumberGenerator.Fill(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken, ApplicationDbContext context)
        {
            var refreshTokenDb = await context.RefreshToken.
                FirstOrDefaultAsync(rt => rt.Token == refreshToken && 
                    rt.RevokedAt != null && 
                    rt.ExpiresAt > DateTimeOffset.UtcNow);

            if (refreshTokenDb == null)
            {
                return false;
            }

            return true;
        }
    }
}
