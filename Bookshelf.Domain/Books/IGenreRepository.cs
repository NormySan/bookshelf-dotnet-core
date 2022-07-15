using Bookshelf.Domain.Common;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Books
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<Genre[]> GetByIdsAsync(int[] ids);
    }
}
