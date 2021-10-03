using Bookshelf.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.Infrastructure.Domain.Books
{
    class BookRepository : IBookRepository
    {
        private readonly DatabaseContext context;

        public BookRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return context.Books.ToListAsync();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            return context.Books.SingleOrDefaultAsync(book => book.Id == id);
        }
    }
}
