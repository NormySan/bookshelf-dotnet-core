using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Queries
{
    public class GetGenresQuery : IRequest<List<Genre>> { }

    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<Genre>>
    {
        private readonly DatabaseContext context;

        public GetGenresQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<List<Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            return context.Genres.ToListAsync(cancellationToken);
        }
    }
}
