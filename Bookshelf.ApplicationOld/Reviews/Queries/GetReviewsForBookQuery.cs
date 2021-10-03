using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Reviews.Queries
{
    public class GetReviewsForBookQuery : IRequest<List<Review>>
    {
        public int Id { get; }

        public GetReviewsForBookQuery(int id)
        {
            Id = id;
        }

        public class GetReviewsForBookQueryHandler : IRequestHandler<GetReviewsForBookQuery, List<Review>>
        {
            private readonly DatabaseContext context;

            public GetReviewsForBookQueryHandler(DatabaseContext context)
            {
                this.context = context;
            }

            public Task<List<Review>> Handle(GetReviewsForBookQuery query, CancellationToken cancellationToken)
            {
                return context.Reviews
                    .Where(review => review.BookId == query.Id)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
