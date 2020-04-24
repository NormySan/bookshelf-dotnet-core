using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(eb => {
                eb.ToTable("authors");

                eb.Property(author => author.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                eb.Property(author => author.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");

                eb.Property(author => author.Biography)
                    .HasColumnName("biography")
                    .HasDefaultValue(null)
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Book>(eb => {
                eb.ToTable("books");

                eb.Property(book => book.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                eb.Property(book => book.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar");

                eb.Property(book => book.Description)
                    .HasColumnName("description")
                    .HasDefaultValue(null)
                    .HasColumnType("text");

                eb.Property(book => book.ISBN)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasColumnType("char")
                    .HasMaxLength(13)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BookAuthor>(eb => {
                eb.ToTable("authors_books");
                eb.HasKey(t => new { t.AuthorId, t.BookId });

                eb.Property(t => t.AuthorId)
                    .HasColumnName("author_id");

                eb.Property(t => t.BookId)
                    .HasColumnName("book_id");

                eb.HasOne(t => t.Author)
                    .WithMany(t => t.Books)
                    .HasForeignKey(t => t.AuthorId);

                eb.HasOne(t => t.Book)
                    .WithMany(t => t.Authors)
                    .HasForeignKey(t => t.BookId);
            });

            modelBuilder.Entity<BookGenre>(eb => {
                eb.ToTable("books_genres");
                eb.HasKey(t => new { t.BookId, t.GenreId });

                eb.Property(t => t.BookId)
                    .HasColumnName("book_id");

                eb.Property(t => t.BookId)
                    .HasColumnName("genre_id");

                eb.HasOne(t => t.Book)
                    .WithMany(t => t.Genres)
                    .HasForeignKey(t => t.BookId);

                eb.HasOne(t => t.Genre)
                    .WithMany(t => t.Books)
                    .HasForeignKey(t => t.GenreId);
            });

            modelBuilder.Entity<Genre>(eb => {
                eb.ToTable("genres");

                eb.Property(genre => genre.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                eb.Property(genre => genre.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar");
            });
        }
    }
}
