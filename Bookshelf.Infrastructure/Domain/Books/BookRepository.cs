using Bookshelf.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Book>> GetAllAsync(int limit, SortByOptions sortBy)
        {
            var query = context.Books;

            switch (sortBy)
            {
                case SortByOptions.Latest:
                    query.OrderBy(book => book.Published);
                    break;

                case SortByOptions.Rating:
                    query.OrderBy(book => book.Rating);
                    break;
            }

            return query.ToListAsync();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            return context.Books.SingleOrDefaultAsync(book => book.Id == id);
        }
    }
}
