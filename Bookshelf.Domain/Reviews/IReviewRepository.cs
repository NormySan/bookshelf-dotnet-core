using Bookshelf.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Reviews
{
    public interface IReviewRepository : IRepository<Review>
    {
        public Task<List<Review>> GetAllByBookIdAsync(int bookId);

        public Task<double> GetRatingByBookIdAsync(int bookId);

        public Task<IReadOnlyDictionary<int, double>> GetRatingByBookIdsAsync(IReadOnlyList<int> bookIds);
    }
}
