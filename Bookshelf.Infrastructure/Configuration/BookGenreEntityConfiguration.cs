using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Configuration
{
    class BookGenreEntityConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.ToTable("books_genres")
                .HasKey(t => new { t.BookId, t.GenreId });

            builder.Property(t => t.BookId)
                .HasColumnName("book_id");

            builder.Property(t => t.GenreId)
                .HasColumnName("genre_id");

            builder.HasOne(t => t.Book)
                .WithMany(book => book.Genres)
                .HasForeignKey(t => t.BookId);

            builder.HasOne(t => t.Genre)
                .WithMany(genre => genre.Books)
                .HasForeignKey(t => t.GenreId);
        }
    }
}
