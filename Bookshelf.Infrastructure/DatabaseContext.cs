using Bookshelf.Domain.Books;
using Bookshelf.Domain.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();

        public DbSet<Book> Books => Set<Book>();

        public DbSet<Genre> Genres => Set<Genre>();

        public DbSet<Review> Reviews => Set<Review>();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

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
