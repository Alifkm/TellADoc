using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TellADoc.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<RefreshToken> RefreshTokens { get; set;  } = new List<RefreshToken>();
    }
}
