using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using TellADoc.API.Models;

namespace TellADoc.API.Services
{
    public class PasswordHashGenerator
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordHashGenerator()
        { 
            _passwordHasher = new PasswordHasher<User>();
        }

        public string GenerateHash(string password)
        {
            return _passwordHasher.HashPassword(new User(), password);
        }

        public bool VerifyHash(string password, string hash)
        {
            var hashedPassword = _passwordHasher.VerifyHashedPassword(new User(), hash, password);

            return hashedPassword == PasswordVerificationResult.Success;
        }
    }
}
