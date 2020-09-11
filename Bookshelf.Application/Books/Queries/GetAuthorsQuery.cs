using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Queries
{
    public class GetAuthorsQuery : IRequest<List<Author>>
    {
    }

    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<Author>>
    {
        private readonly DatabaseContext context;

        public GetAuthorsQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<List<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return context.Authors.ToListAsync(cancellationToken);
        }
    }
}
