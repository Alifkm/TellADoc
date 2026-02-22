using TellADoc.API.Context;
using TellADoc.API.Models;
using TellADoc.API.Services;

namespace TellADoc.API.Seeder
{
    public static class DbSeeder
    {
        static PasswordHashGenerator hashGenerator = new PasswordHashGenerator();

        public static void SeedDocuments(ApplicationDbContext _context)
        {
            if (!_context.User.Any())
            {
                IEnumerable<User> users = new List<User>()
                {
                    new User()
                    {
                        Username = "admin",
                        Email = "admin@gmail.com",
                        PasswordHash = hashGenerator.GenerateHash("admin123"),
                        Role = "ADMIN",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    },
                     new User()
                    {
                        Username = "user",
                        Email = "user@gmail.com",
                        PasswordHash = hashGenerator.GenerateHash("userNihBos"),
                        Role = "USER",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    }
                };
                _context.User.AddRange(users);
                _context.SaveChanges();
            }

            if (!_context.Document.Any())
            {
                IEnumerable<Document> documents = new List<Document>()
                {
                    new Document()
                    {
                        UserId = 9,
                        FileName = "Document_cuy.PDF",
                        FileType = "PDF",
                        FileSize = 2,
                        StoragePath = "",
                        AiStatus = "PENDING",
                        SummaryText = "",
                        Language = "EN",
                        PageCount = 10,
                        ProcessingTimeSeconds = 10,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        IsDeleted = false,
                    }
                };
                _context.Document.AddRange(documents);
                _context.SaveChanges();
            }
        }
    }
}
