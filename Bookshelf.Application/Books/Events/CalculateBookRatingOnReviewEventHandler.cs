using Bookshelf.Application.Reviews.Events;
using Bookshelf.Domain.Books;
using Bookshelf.Domain.Reviews;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Events;

public class CalculateBookRatingOnReviewEventHandler : INotificationHandler<ReviewAddedEvent>
{
    private IBookRepository BookRepository { get; }

    private IReviewRepository ReviewRepository { get; }

    public CalculateBookRatingOnReviewEventHandler(IBookRepository bookRepository,IReviewRepository reviewRepository)
    {
        BookRepository = bookRepository;
        ReviewRepository = reviewRepository;
    }


    public async Task Handle(ReviewAddedEvent notification, CancellationToken cancellationToken)
    {
        var book = await BookRepository.GetByIdAsync(notification.BookId);

        if (book == null)
        {
            return;
        }

        var rating = await ReviewRepository.GetRatingByBookIdAsync(notification.BookId);
        
        book.SetRating(rating);
        await BookRepository.Add(book);

        return;
    }
}
