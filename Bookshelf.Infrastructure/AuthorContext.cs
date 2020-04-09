using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure
{
    public class AuthorContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(eb => {
                eb.Property(author => author.Name)
                    .IsRequired();

                eb.Property(author => author.Biography)
                    .IsRequired()
                    .HasColumnType("text");
            });
        }
    }
}
