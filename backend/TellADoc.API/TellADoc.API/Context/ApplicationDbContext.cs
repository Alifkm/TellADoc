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
        public DbSet<User> User { get; set; }
        
        public DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasQueryFilter(row => !row.IsDeleted);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Documents)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId)
            .IsRequired();
        }

    }
}
