using Bookshelf.Domain.Series;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Domain.Books
{
    class SeriesBookEntityConfiguration : IEntityTypeConfiguration<SeriesBook>
    {
        public void Configure(EntityTypeBuilder<SeriesBook> builder)
        {
            builder.ToTable("series_books")
                .HasKey(seriesBook => seriesBook.Id);

            builder.Property(seriesBook => seriesBook.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(seriesBook => seriesBook.BookId)
                .IsRequired()
                .HasColumnName("book_id")
                .HasColumnType("integer");

            builder.Property(seriesBook => seriesBook.Order)
                .IsRequired()
                .HasColumnName("order")
                .HasColumnType("integer");
        }
    }
}
