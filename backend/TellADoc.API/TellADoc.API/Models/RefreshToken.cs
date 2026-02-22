using System.ComponentModel.DataAnnotations;

namespace TellADoc.API.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required string Token { get; set; }
        public required DateTimeOffset ExpiresAt { get; set; }
        public required DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? RevokedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
