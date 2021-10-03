using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Books
{
    public interface IBookRepository
    {
        public Task<Book> GetByIdAsync(int id);

        public Task<List<Book>> GetAllAsync();
    }
}
