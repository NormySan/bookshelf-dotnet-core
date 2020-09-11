using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Configuration
{
    class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("authors_books")
                .HasKey(t => new { t.AuthorId, t.BookId });

            builder.Property(t => t.AuthorId)
                .HasColumnName("author_id");

            builder.Property(t => t.BookId)
                .HasColumnName("book_id");

            builder.HasOne(t => t.Author)
                .WithMany(t => t.Books)
                .HasForeignKey(t => t.AuthorId);

            builder.HasOne(t => t.Book)
                .WithMany(t => t.Authors)
                .HasForeignKey(t => t.BookId);
        }
    }
}
