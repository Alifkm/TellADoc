using TellADoc.API.Context;
using TellADoc.API.Models;

namespace TellADoc.API.Seeder
{
    public static class DbSeeder
    {
        public static void SeedDocuments(ApplicationDbContext _context)
        {
            if(!_context.Document.Any())
            {
                IEnumerable<Document> documents = new List<Document>()
                {
                    new Document()
                    {
                        Name = "Document_AHAY.PDF",
                        Type = "PDF",
                        Size = 10.0f,
                        Created_At = DateTime.UtcNow,
                        Updated_At = DateTime.UtcNow,
                    }
                };
                _context.Document.AddRange(documents);
                _context.SaveChanges();
            }

            
        }
    }
}
