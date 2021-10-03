using Bookshelf.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Domain.Books
{
    class SeriesEntityConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("series")
                .HasKey(series => series.Id);

            builder.Property(series => series.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(series => series.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("text");
        }
    }
}
