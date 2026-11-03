using Microsoft.EntityFrameworkCore;
using WikiSumBackend.Domain.Entiteiten;

namespace WikiSumBackend.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Webpage> Webpage { get; set; }

        public DbSet<Chapter> Chapter { get; set; }

        public DbSet<Summary> Summary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Webpage 1 -> * Chapter
            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.Webpage)
                .WithMany(w => w.Chapters)
                .HasForeignKey(c => c.WebpageId)
                .OnDelete(DeleteBehavior.Cascade);

            // Chapter 1 -> * Summary
            modelBuilder.Entity<Summary>()
                .HasOne(s => s.Chapter)
                .WithMany(c => c.Summaries)
                .HasForeignKey(s => s.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Required properties
            modelBuilder.Entity<Webpage>()
                .Property(w => w.Url)
                .IsRequired();

            modelBuilder.Entity<Chapter>()
                .Property(c => c.Title)
                .IsRequired();

            modelBuilder.Entity<Summary>()
                .Property(s => s.SummaryText)
                .IsRequired();

            modelBuilder.Entity<Summary>()
                .Property(s => s.Language)
                .IsRequired();
        }
    }
}
