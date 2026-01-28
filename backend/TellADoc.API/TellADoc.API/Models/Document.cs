using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TellADoc.API.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string StoragePath { get; set; }
        public string AiStatus { get; set; }
        public string SummaryText { get; set; }
        public string Language { get; set; }
        public int PageCount { get; set; }
        public int ProcessingTimeSeconds { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        [AllowNull]
        public DateTimeOffset? DeletedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
