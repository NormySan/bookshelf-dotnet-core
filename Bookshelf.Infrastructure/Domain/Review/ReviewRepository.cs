using Bookshelf.Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Infrastructure.Domain.Reviews;

internal class BookRatingResult
{
    public required int BookId { get; set; }
    public required double Rating { get; set; }
}

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
        //var value = await context.Reviews
        //    .Where(review => review.BookId == bookId)
        //    .AverageAsync(review => review.Rating.Value);

        //return Math.Round(value, 1);

        var rating = await context.Database
            .SqlQuery<double>($"SELECT COALESCE(AVG(rating), 0) AS Value FROM reviews WHERE book_id = {bookId}")
            .SingleAsync();

        return Math.Round(rating, 1);
    }

    /// <summary>Yolo.</summary>
    public async Task<IReadOnlyDictionary<int, double>> GetRatingByBookIdsAsync(IReadOnlyList<int> bookIds)
    {
        return await context.Database
            .SqlQuery<BookRatingResult>($@"
                SELECT
	                ROUND(COALESCE(AVG(rating), 0), 2) AS Rating,
	                book_id AS BookId
                FROM reviews
                WHERE book_id IN ({bookIds})
                GROUP BY book_id
            ")
            .ToDictionaryAsync(
                result => result.BookId,
                result => result.Rating
            );
    }

    public Task<Review> Update(Review entity)
    {
        throw new NotImplementedException();
    }
}
