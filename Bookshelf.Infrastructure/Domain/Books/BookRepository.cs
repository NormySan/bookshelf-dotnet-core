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

        public async Task<Book> Add(Book entity)
        {
            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task AddAsync(Book entity)
        {
            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<Book>> GetAllAsync()
        {
            return context.Books.ToListAsync();
        }

        public Task<List<Book>> GetAllAsync(int limit, SortByOptions? sortBy = null)
        {
            var query = context.Books;

            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case SortByOptions.Latest:
                        query.OrderBy(book => book.Published);
                        break;

                    case SortByOptions.Rating:
                        query.OrderBy(book => book.Rating);
                        break;
                }
            }

            return query.Take(limit).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await context.Books.SingleOrDefaultAsync(book => book.Id == id);

            if (book == null)
            {
                return null;
            }

            return book;
        }

        public async Task<Book> Update(Book entity)
        {
            context.Books.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
