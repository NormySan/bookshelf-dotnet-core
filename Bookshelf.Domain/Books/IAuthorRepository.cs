using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Books
{
    public interface IAuthorRepository
    {
        public Task<Author?> GetByIdAsync(int id);

        public Task<List<Author>> GetAllAsync();
    }
}
