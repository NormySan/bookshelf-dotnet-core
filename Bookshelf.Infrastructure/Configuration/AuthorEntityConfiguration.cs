using Bookshelf.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Configuration
{
    class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors")
                .HasKey(author => author.Id);

            builder.Property(author => author.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(author => author.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar");

            builder.Property(author => author.Biography)
                .HasColumnName("biography")
                .HasDefaultValue(null)
                .HasColumnType("text");
        }
    }
}
