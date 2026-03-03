using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TellADoc.API.Models;
using TellADoc.API.Services;
using TellADoc.API.Context;
using Microsoft.EntityFrameworkCore;

namespace TellADoc.API.Controllers
{
    public class AuthController : Controller
    {
        private AuthService _authService;
        private readonly ApplicationDbContext _context;
        private readonly PasswordHashGenerator _passwordHashGenerator = new();

        public AuthController(AuthService tokenGenerator, ApplicationDbContext context)
        {
            _authService = tokenGenerator;
            _context = context;
        }

        [AllowAnonymous]
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return Unauthorized("Email or Password is wrong");
            }

            bool isPasswordValid = _passwordHashGenerator.VerifyHash(request.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized("Email or Password is wrong");
            }

            string accessToken = _authService.GenerateAccessToken(user);
            string refreshToken = _authService.GenerateRefreshToken();

            bool validRefreshToken = await _authService.ValidateRefreshToken(refreshToken, _context);

            if(!validRefreshToken)
            {
                return Unauthorized("Refresh token is invalid");
            }

            await SaveRefreshTokenToDatabase(user, refreshToken);

            return Ok(new { accessToken, refreshToken });
        }

        [Route("/refresh")]
        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        {
            var findRefreshToken = await _context.RefreshToken.FirstOrDefaultAsync(
                rt => rt.Token == request.RefreshToken &&
                rt.ExpiresAt >= DateTimeOffset.UtcNow &&
                rt.RevokedAt == null);

            if (findRefreshToken == null)
            {
                return Unauthorized();
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == findRefreshToken.UserId);

            if (user == null)
            {
                return Unauthorized("User not found");
            }

            string accessToken = _tokenGenerator.GenerateAccessToken(user);
            string refreshToken = _tokenGenerator.GenerateRefreshToken();

            await RevokeRefreshToken(findRefreshToken);
            await SaveRefreshTokenToDatabase(user, refreshToken);

            return Ok(new { accessToken, refreshToken });
        }

        private async Task RevokeRefreshToken(RefreshToken refreshToken)
        {
            refreshToken.RevokedAt = DateTimeOffset.UtcNow;
            await _context.SaveChangesAsync();
        }

        private async Task SaveRefreshTokenToDatabase(User user, string refreshToken)
        {
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                CreatedAt = DateTimeOffset.UtcNow,
                ExpiresAt = DateTimeOffset.UtcNow.AddDays(7)
            };

            _context.RefreshToken.Add(refreshTokenEntity);

            await _context.SaveChangesAsync();
        }
    }
}
