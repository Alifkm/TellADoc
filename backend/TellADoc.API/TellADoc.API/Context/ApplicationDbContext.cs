using Microsoft.EntityFrameworkCore;
using TellADoc.API.Models;

namespace TellADoc.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Document> Document { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasQueryFilter(row => !row.IsDeleted);
        }

    }
}
