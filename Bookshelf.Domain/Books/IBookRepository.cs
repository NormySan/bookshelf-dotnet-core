using Bookshelf.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Books
{
    public enum SortByOptions
    {
        Latest,
        Rating,
    }

    public interface IBookRepository : IRepository<Book>
    {
        public Task<List<Book>> GetAllAsync();

        public Task<List<Book>> GetAllAsync(int limit, SortByOptions? sortBy);
    }
}
