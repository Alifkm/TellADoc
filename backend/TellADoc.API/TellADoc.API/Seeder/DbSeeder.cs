using TellADoc.API.Context;
using TellADoc.API.Models;

namespace TellADoc.API.Seeder
{
    public static class DbSeeder
    {
        public static void SeedDocuments(ApplicationDbContext _context)
        {
            //if(!_context.Document.Any())
            //{
                IEnumerable<Document> documents = new List<Document>()
                {
                    new Document()
                    {
                        Name = "Report_nih.xlsx",
                        Type = "EXCEL",
                        Size = 5.0f,
                        Created_At = DateTime.UtcNow,
                        Updated_At = DateTime.UtcNow,
                    }
                };
                _context.Document.AddRange(documents);
                _context.SaveChanges();
            //}
        }
    }
}
