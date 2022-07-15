using Bookshelf.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Infrastructure.Domain.Reviews
{
    class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews")
                .HasKey(review => review.Id);

            builder.Property(review => review.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(review => review.BookId)
                .HasColumnName("book_id");

            builder.Property(review => review.Content)
                .HasColumnName("content");

            builder.Property(review => review.Rating)
                .HasColumnName("rating")
                .IsRequired();
        }
    }
}
