using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Configuration
{
    class BookEntityConfiguration : IEntityTypeConfiguration<Book>
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
                .HasDefaultValue(null)
                .HasColumnType("text");

            builder.Property(book => book.ISBN)
                .IsRequired()
                .HasColumnName("isbn")
                .HasColumnType("char")
                .HasMaxLength(13)
                .IsFixedLength();
        }
    }
}
