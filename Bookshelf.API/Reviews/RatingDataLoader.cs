using Bookshelf.Domain.Reviews;
using GreenDonut;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.API.Reviews
{
    public class RatingDataLoader : BatchDataLoader<int, double>
    {
        private IReviewRepository ReviewRepository { get; }

        public RatingDataLoader(
            IReviewRepository reviewRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null
        ) : base(batchScheduler, options)
        {
            ReviewRepository = reviewRepository;
        }

        protected override Task<IReadOnlyDictionary<int, double>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken
        )
        {
            return ReviewRepository.GetRatingByBookIdsAsync(keys);
        }
    }
}
