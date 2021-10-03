using MediatR;
using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.ApplicationOld.Books.Queries
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

        public Task<Book> Handle(GetBookQuery query, CancellationToken cancellationToken)
        {
            return context.Books
                .Include(book => book.Authors)
                .ThenInclude(bookAuthors => bookAuthors.Author)
                .Include(book => book.Genres)
                .ThenInclude(bookGenres => bookGenres.Genre)
                .SingleOrDefaultAsync(
                    book => book.Id == query.Id,
                    cancellationToken
                );
        }
    }
}
