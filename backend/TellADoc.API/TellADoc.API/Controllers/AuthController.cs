using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TellADoc.API.Identity;
using TellADoc.API.Models;

namespace TellADoc.API.Controllers
{
    public class AuthController : Controller
    {
        private TokenGenerator _tokenGenerator;

        public AuthController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [AllowAnonymous]
        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            string token = _tokenGenerator.GenerateToken(user.Email);

            return Ok(new { token });
        }
    }
}
