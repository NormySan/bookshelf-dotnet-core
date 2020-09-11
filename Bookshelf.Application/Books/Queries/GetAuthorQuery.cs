using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Queries
{
    public class GetAuthorQuery : IRequest<Author>
    {
        public int Id { get; }

        public GetAuthorQuery(int id)
        {
            Id = id;
        }
    }

    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, Author>
    {
        private DatabaseContext context;

        public GetAuthorQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Author> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return context.Authors.SingleAsync(author => author.Id == request.Id, cancellationToken);
        }
    }
}
