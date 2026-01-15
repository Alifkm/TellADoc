using System.ComponentModel.DataAnnotations;

namespace TellADoc.API.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
