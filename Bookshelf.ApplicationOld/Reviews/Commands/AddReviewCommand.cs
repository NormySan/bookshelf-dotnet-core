using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Reviews.Commands
{
    public class AddReviewCommand : IRequest<int>
    {
        public int BookId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }

    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, int>
    {
        private readonly DatabaseContext context;

        public AddReviewCommandHandler(DatabaseContext database)
        {
            this.context = database;
        }

        public async Task<int> Handle(AddReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Review(
                command.BookId,
                command.Content,
                command.Rating
            );

            context.Add(review);
            await context.SaveChangesAsync(cancellationToken);

            return review.Id;
        }
    }
}
