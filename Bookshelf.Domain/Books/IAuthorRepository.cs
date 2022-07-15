using Bookshelf.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Domain.Books
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public Task<Author[]> GetByIdsAsync(int[] ids);

        public Task<List<Author>> GetAllAsync();
    }
}
