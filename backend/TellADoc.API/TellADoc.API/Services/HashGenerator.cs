using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using TellADoc.API.Models;

namespace TellADoc.API.Services
{
    public class HashGenerator
    {
        public static string GenerateHashPassword(string password)
        {
            //byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            //    password: password!,
            //    salt: salt,
            //    prf: KeyDerivationPrf.HMACSHA256,
            //    iterationCount: 100000,
            //    numBytesRequested: 256 / 8
            //    ));


            var user = new User();
            var hasher = new PasswordHasher<User>();

            string hashedPassword = hasher.HashPassword(user, password);

            return hashedPassword;
            //return hashed;
            //return hasher;
        }
    }
}
