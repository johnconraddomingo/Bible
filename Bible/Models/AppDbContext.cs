using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bible.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAlias> BookAliases { get; set; }
        public virtual DbSet<BookDescription> BookDescriptions { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Footnote> Footnotes { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<Verse> Verses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TranslationNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Translation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Translations");
            });

            modelBuilder.Entity<BookAlias>(entity =>
            {
                entity.Property(e => e.Alias)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.BookAliases)
                    .HasForeignKey(d => d.Book)
                    .HasConstraintName("FK_BookShortcuts_Books");
            });

            modelBuilder.Entity<BookDescription>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.BookDescriptions)
                    .HasForeignKey(d => d.Book)
                    .HasConstraintName("FK_BookDescriptions_Books");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chapters_Books");
            });

            modelBuilder.Entity<Footnote>(entity =>
            {
                entity.Property(e => e.FootnoteText).IsUnicode(false);

                entity.HasOne(d => d.VerseNavigation)
                    .WithMany(p => p.Footnotes)
                    .HasForeignKey(d => d.Verse)
                    .HasConstraintName("FK_Footnotes_Verses");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.VerseNavigation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.Verse)
                    .HasConstraintName("FK_Titles_Verses");
            });

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TranslationCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TranslationName)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Verse>(entity =>
            {
                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.ChapterNavigation)
                    .WithMany(p => p.Verses)
                    .HasForeignKey(d => d.Chapter)
                    .HasConstraintName("FK_Verses_Chapters");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
