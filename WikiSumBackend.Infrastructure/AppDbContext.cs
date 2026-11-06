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
        public DbSet<ChapterTranslation> ChapterTranslation { get; set; }
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

            // Chapter 1 -> * ChapterTranslation
            modelBuilder.Entity<ChapterTranslation>()
                .HasOne(t => t.Chapter)
                .WithMany(c => c.Translations)
                .HasForeignKey(t => t.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            // ChapterTranslation 1 -> * Summary
            modelBuilder.Entity<Summary>()
                .HasOne(s => s.ChapterTranslation)
                .WithMany(t => t.Summaries)
                .HasForeignKey(s => s.ChapterTranslationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Required properties
            modelBuilder.Entity<Webpage>()
                .Property(w => w.Url)
                .IsRequired();

            modelBuilder.Entity<ChapterTranslation>()
                .Property(t => t.Title)
                .IsRequired();

            modelBuilder.Entity<ChapterTranslation>()
                .Property(t => t.Language)
                .IsRequired();

            modelBuilder.Entity<Summary>()
                .Property(s => s.SummaryText)
                .IsRequired();

            // One translation per language per chapter
            modelBuilder.Entity<ChapterTranslation>()
                .HasIndex(t => new { t.ChapterId, t.Language })
                .IsUnique();
        }
    }
}
