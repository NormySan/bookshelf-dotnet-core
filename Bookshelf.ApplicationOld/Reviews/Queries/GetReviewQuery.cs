using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Reviews.Queries
{
    public class GetReviewQuery : IRequest<Review>
    {
        public int Id { get; }

        public GetReviewQuery(int id)
        {
            Id = id;
        }
    }

    public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, Review>
    {
        private readonly DatabaseContext context;

        public GetReviewQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Review> Handle(GetReviewQuery query, CancellationToken cancellationToken)
        {
            return context.Reviews.SingleOrDefaultAsync(
                review => review.Id == query.Id,
                cancellationToken
            );
        }
    }
}
