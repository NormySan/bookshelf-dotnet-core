using MediatR;
using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Application.Books.Queries
{
    public class GetBookQuery : IRequest<Book>
    {
        public int Id { get; }

        public GetBookQuery(int id)
        {
            Id = id;
        }
    }

    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
    {
        private DatabaseContext context;

        public GetBookQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return context.Books
                .Include(book => book.Authors)
                .ThenInclude(bookAuthors => bookAuthors.Author)
                .Include(book => book.Genres)
                .ThenInclude(bookGenres => bookGenres.Genre)
                .SingleAsync(book => book.Id == request.Id, cancellationToken);
        }
    }
}
