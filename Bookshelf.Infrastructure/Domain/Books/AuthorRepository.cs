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
        public Task<List<Author>> GetAllAsync()
        {
            return context.Authors.ToListAsync();
        }

        public Task<Author?> GetByIdAsync(int id)
        {
            return context.Authors.Where(author => author.Id == id).FirstOrDefaultAsync();
        }
    }
}
