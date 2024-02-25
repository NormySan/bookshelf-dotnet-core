using MediatR;

namespace Bookshelf.Application.Reviews.Events;

public class ReviewAddedEvent : INotification
{
    public readonly int BookId;

    public readonly int ReviewId;

    public ReviewAddedEvent(int bookId, int reviewId)
    {
        BookId = bookId;
        ReviewId = reviewId;
    }
}
