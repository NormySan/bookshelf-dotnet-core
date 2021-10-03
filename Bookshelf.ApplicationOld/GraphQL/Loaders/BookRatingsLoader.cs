using Bookshelf.Infrastructure;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.GraphQL.Loaders
{
    public interface IBookRatingsLoader : IDataLoader<int, double> { }

    public class BookRatingsLoader : BatchDataLoader<int, double>, IBookRatingsLoader
    {
        private readonly DatabaseContext context;

        public BookRatingsLoader(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task<IReadOnlyDictionary<int, double>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken
        )
        {
            var result = await context.Reviews
                .Where(review => keys.Contains(review.BookId))
                .GroupBy(
                    review => review.BookId,
                    review => review.Rating
                )
                .Select(group => new
                {
                    BookId = group.Key,
                    Rating = group.Average()
                })
                .ToDictionaryAsync(
                    result => result.BookId,
                    result => result.Rating,
                    cancellationToken
                );

            return result;
        }
    }
}
