using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new Configuration.AuthorEntityConfiguration())
                .ApplyConfiguration(new Configuration.BookEntityConfiguration())
                .ApplyConfiguration(new Configuration.BookAuthorEntityConfiguration())
                .ApplyConfiguration(new Configuration.BookGenreEntityConfiguration())
                .ApplyConfiguration(new Configuration.GenreEntityConfiguration());
        }
    }
}
