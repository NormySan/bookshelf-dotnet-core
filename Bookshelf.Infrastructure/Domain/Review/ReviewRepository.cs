using Bookshelf.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Infrastructure.Domain.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DatabaseContext context;

        public ReviewRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Review> Add(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAllByBookIdAsync(int bookId)
        {
            return context.Reviews
                .Where(review => review.BookId == bookId)
                .ToListAsync();
        }

        public Task<Review?> GetByIdAsync(int id)
        {
            return context.Reviews
                .Where(review => review.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<double> GetRatingByBookIdAsync(int bookId)
        {
            var value = await context.Reviews
                .Where(review => review.BookId == bookId)
                .Select(review => review.Rating)
                .DefaultIfEmpty()
                .AverageAsync();

            return Math.Round(value, 1);
        }

        /// <summary>This method does not work because of limitations in EF Core.</summary>
        public async Task<IReadOnlyDictionary<int, double>> GetRatingByBookIdsAsync(IReadOnlyList<int> bookIds)
        {
            var ratings = new Dictionary<int, double>();

            foreach (var id in bookIds)
            {
                ratings.Add(id, 0.0);
            }

            var result = await context.Reviews
                .GroupBy(review => review.BookId)
                .Where(group => bookIds.Contains(group.Key))
                .ToDictionaryAsync(
                    group => group.Key,
                    group => group.Average(review => review.Rating)
                );

            foreach (var rating in result)
            {
                ratings[rating.Key] = Math.Round(rating.Value, 1);
            }

            return ratings;
        }

        public Task<Review> Update(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
