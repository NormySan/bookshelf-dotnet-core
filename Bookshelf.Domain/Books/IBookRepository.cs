using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Books
{
    public enum SortByOptions
    {
        None,
        Latest,
        Rating,
    }

    public enum SortDirection
    {
        Ascending,
        Descending,
    }

    public class SortingOptions
    {
        public SortByOptions SortBy { get; }
        public SortDirection Direction { get; }

        SortingOptions(
            SortByOptions sortBy = SortByOptions.None,
            SortDirection direction = SortDirection.Ascending
        )
        {
            SortBy = sortBy;
            Direction = direction;
        }
    }

    public interface IBookRepository
    {
        public Task<Book> GetByIdAsync(int id);

        public Task<List<Book>> GetAllAsync();

        public Task<List<Book>> GetAllAsync(int limit, SortByOptions sortBy);
    }
}
