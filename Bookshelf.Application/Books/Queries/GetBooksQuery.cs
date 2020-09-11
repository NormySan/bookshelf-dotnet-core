using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Queries
{
    public class GetBooksQuery : IRequest<List<Book>> { }

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Book>>
    {
        private readonly DatabaseContext context;

        public GetBooksQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return context.Books
                .Include(book => book.Authors)
                .ThenInclude(bookAuthors => bookAuthors.Author)
                .Include(book => book.Genres)
                .ThenInclude(bookGenres => bookGenres.Genre)
                .ToListAsync(cancellationToken);
        }
    }
}
