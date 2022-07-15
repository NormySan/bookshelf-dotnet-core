using Bookshelf.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Infrastructure.Domain.Books
{
    class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext context;

        public AuthorRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Author> Add(Author entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Author>> GetAllAsync()
        {
            return context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            var author = await context.Authors
                .Where(author => author.Id == id)
                .FirstOrDefaultAsync();

            return author ?? null;
        }

        public Task<Author[]> GetByIdsAsync(int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public Task<Author> Update(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
