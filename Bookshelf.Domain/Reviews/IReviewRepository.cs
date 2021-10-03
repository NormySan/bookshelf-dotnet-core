using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Reviews
{
    public interface IReviewRepository
    {
        public Task<Review> GetByIdAsync(int id);

        public Task<List<Review>> GetAllByBookIdAsync(int bookId);

        public Task<double> GetRatingByBookIdAsync(int bookId);

        public Task<IReadOnlyDictionary<int, double>> GetRatingByBookIdsAsync(IReadOnlyList<int> bookIds);
    }
}
