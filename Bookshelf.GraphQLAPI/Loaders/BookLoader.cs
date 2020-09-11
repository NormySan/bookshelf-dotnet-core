using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.GraphQLAPI.Loaders
{
    public class BookLoader
    {
        private DatabaseContext context { get; }

        public BookLoader(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<ILookup<int, Book>> GetBooksByAuthorIds(IEnumerable<int> authorIds, CancellationToken cancellationToken)
        {
            var result = await context.BookAuthor
                 .Where(bookAuthor => authorIds.Contains(bookAuthor.AuthorId))
                 .Include(bookAuthor => bookAuthor.Book)
                 .Select(bookAuthor => new
                 {
                     bookAuthor.Book,
                     bookAuthor.AuthorId,
                 })
                 .ToListAsync(cancellationToken);

            return result.ToLookup(result => result.AuthorId, result => result.Book);
        }
    }
}
