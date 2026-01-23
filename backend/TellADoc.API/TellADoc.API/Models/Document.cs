using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TellADoc.API.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string StoragePath { get; set; }
        public string AiStatus { get; set; }
        public string SummaryText { get; set; }
        public string Language { get; set; }
        public int PageCount { get; set; }
        public int ProcessingTimeSeconds { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        [AllowNull]
        public DateTime DeletedAt { get; set; }
    }
}
