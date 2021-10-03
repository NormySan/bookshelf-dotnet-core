using Bookshelf.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Bookshelf.Infrastructure.Domain.Books
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books")
                .HasKey(book => book.Id);

            builder.Property(book => book.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(book => book.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("varchar");

            builder.Property(book => book.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(book => book.ISBN)
                .IsRequired()
                .HasColumnName("isbn")
                .HasColumnType("char")
                .HasMaxLength(13)
                .IsFixedLength();

            builder.Property(book => book.Published)
                .IsRequired()
                .HasColumnName("published")
                .HasColumnType("text");

            builder.Property(book => book.Pages)
                .IsRequired()
                .HasColumnName("pages")
                .HasColumnType("integer");

            builder.HasMany(book => book.Authors)
                .WithMany("Books")
                .UsingEntity<Dictionary<string, object>>(
                    "authors_books",
                    right => right
                        .HasOne<Author>()
                        .WithMany()
                        .HasForeignKey("author_id"),
                    left => left
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("book_id")
                );

            builder.HasMany(book => book.Genres)
                .WithMany("Books")
                .UsingEntity<Dictionary<string, object>>(
                    "books_genres",
                    right => right
                        .HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("genre_id"),
                    left => left
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("book_id")
                );

            builder.Navigation(book => book.Authors).AutoInclude();
            builder.Navigation(book => book.Genres).AutoInclude();
        }
    }
}
