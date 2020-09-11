using MediatR;
using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Application.Books.Queries
{
    public class GetGenreQuery : IRequest<Genre>
    {
        public int Id { get; }

        public GetGenreQuery(int id)
        {
            Id = id;
        }
    }

    public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, Genre>
    {
        private DatabaseContext context;

        public GetGenreQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Genre> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            return context.Genres.SingleAsync(genre => genre.Id == request.Id, cancellationToken);
        }
    }
}
