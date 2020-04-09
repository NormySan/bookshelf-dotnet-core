using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public BookContext(DbContextOptions<BookContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(eb => {
                eb.Property(book => book.Title)
                    .IsRequired()
                    .HasColumnType("varchar");

                eb.Property(book => book.Description)
                    .HasColumnType("text");

                eb.Property(book => book.ISBN)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasMaxLength(13)
                    .IsFixedLength();
            });
        }
    }
}
