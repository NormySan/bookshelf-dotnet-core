using Bookshelf.Domain.Books;
using Bookshelf.Domain.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new Domain.Books.AuthorEntityConfiguration())
                .ApplyConfiguration(new Domain.Books.BookEntityConfiguration())
                .ApplyConfiguration(new Domain.Books.GenreEntityConfiguration());

            builder
                .ApplyConfiguration(new Domain.Reviews.ReviewEntityConfiguration());
        }
    }
}
