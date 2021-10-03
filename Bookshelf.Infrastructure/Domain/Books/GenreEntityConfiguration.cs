using Bookshelf.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Domain.Books
{
    class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genres")
                .HasKey(genre => genre.Id);

            builder.Property(genre => genre.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(genre => genre.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar");
        }
    }
}
