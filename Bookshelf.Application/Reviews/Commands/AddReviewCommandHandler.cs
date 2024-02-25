using Bookshelf.Application.Reviews.Events;
using Bookshelf.Domain.Reviews;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Reviews.Commands
{
    public class AddReviewCommand: IRequest<int>
    {
        public readonly int BookId;

        public readonly Rating Rating;

        public readonly string Content;

        public AddReviewCommand(int bookId, Rating rating, string content)
        {
            BookId = bookId;
            Rating = rating;
            Content = content;
        }
    }

    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, int>
    {
        private readonly IReviewRepository ReviewRepository;

        private readonly IMediator Mediator;

        public AddReviewCommandHandler(
            IReviewRepository reviewRepository,
            IMediator mediator
        )
        {
            ReviewRepository = reviewRepository;
            Mediator = mediator;
        }

        public async Task<int> Handle(AddReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Review(command.BookId, command.Content, command.Rating);

            await ReviewRepository.Add(review);

            await Mediator.Publish(new ReviewAddedEvent(review.BookId, review.Id), cancellationToken);

            return review.Id;
        }
    }
}
