using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TellADoc.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
