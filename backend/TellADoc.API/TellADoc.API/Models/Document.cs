using System.ComponentModel.DataAnnotations;

namespace TellADoc.API.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }
        public string Type { get; set; }
        public float Size { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
