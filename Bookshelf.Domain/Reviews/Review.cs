using System;

namespace Bookshelf.Domain.Reviews
{
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; }

        public string Content { get; }

        public int Rating { get; }

        public DateTime CreatedAt { get; }

        public Review(int bookId, string content, Rating rating)
        {
            BookId = bookId;
            Content = content;
            Rating = rating.Value;
            CreatedAt = new DateTime();
        }
    }
}
