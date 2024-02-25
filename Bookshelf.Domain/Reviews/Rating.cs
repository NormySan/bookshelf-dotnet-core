using System;

namespace Bookshelf.Domain.Reviews
{
    public class Rating
    {
        public readonly int Value;

        public Rating(int rating)
        {
            Value = Math.Clamp(rating, 1, 5);
        }
    }
}
