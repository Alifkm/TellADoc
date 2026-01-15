using Microsoft.EntityFrameworkCore;
using TellADoc.API.Models;

namespace TellADoc.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public Document document { get; set; }
    }
}
