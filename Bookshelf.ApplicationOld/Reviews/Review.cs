using System;

namespace Bookshelf.Domain
{
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; }

        public string Content { get; }

        public int Rating { get; }

        public Review(int bookId, string content, int rating)
        {
            BookId = bookId;
            Content = content;
            Rating = Math.Clamp(rating, 1, 5);
        }
    }
}
