using Bookshelf.ApplicationOld.Books.Commands;
using Bookshelf.ApplicationOld.Books.Queries;
using Bookshelf.ApplicationOld.GraphQL.Input;
using Bookshelf.ApplicationOld.Reviews.Commands;
using Bookshelf.ApplicationOld.Reviews.Queries;
using HotChocolate.Types;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.ApplicationOld.GraphQL.Types
{
    public class MutationType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("addAuthor")
                .Argument("input", argument => argument.Type<NonNullType<AuthorInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var input = context.Argument<AuthorInput>("input");

                    var command = new AddAuthorCommand
                    {
                        Name = input.Name.Trim(),
                        Biography = input.Biography.Trim(),
                    };

                    var id = await context
                        .Service<IMediator>()
                        .Send(command, cancellationToken);

                    var author = await context
                        .Service<IMediator>()
                        .Send(new GetAuthorQuery(id), cancellationToken);

                    return author;
                });

            descriptor.Field("addBook")
                .Argument("input", argument => argument.Type<NonNullType<BookInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var input = context.Argument<BookInput>("input");

                    var genres = new List<int>(input.Genres.Select(int.Parse).ToList());
                    var authors = new List<int>(input.Authors.Select(int.Parse).ToList());

                    var command = new AddBookCommand
                    {
                        Title = input.Title.Trim(),
                        Description = input.Description.Trim(),
                        ISBN = input.ISBN,
                        Genres = genres,
                        Authors = authors,
                    };

                    var id = await context
                        .Service<IMediator>()
                        .Send(command, cancellationToken);

                    var author = await context
                        .Service<IMediator>()
                        .Send(new GetBookQuery(id), cancellationToken);

                    return author;
                });

            descriptor.Field("addGenre")
                .Argument("input", argument => argument.Type<NonNullType<GenreInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var input = context.Argument<GenreInput>("input");

                    var command = new AddGenreCommand
                    {
                        Name = input.Name.Trim(),
                    };

                    var id = await context
                        .Service<IMediator>()
                        .Send(command, cancellationToken);

                    var genre = await context
                        .Service<IMediator>()
                        .Send(new GetGenreQuery(id), cancellationToken);

                    return genre;
                });

            descriptor.Field("addReview")
                .Argument("book", argument => argument.Type<NonNullType<IdType>>())
                .Argument("input", argument => argument.Type<NonNullType<ReviewInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var bookId = context.Argument<string>("book");
                    var input = context.Argument<ReviewInput>("input");

                    var command = new AddReviewCommand
                    {
                        BookId = int.Parse(bookId),
                        Content = input.Content,
                        Rating = input.Rating
                    };

                    var reviewId = await context.Service<IMediator>()
                        .Send(command, cancellationToken);

                    var review = await context.Service<IMediator>()
                        .Send(new GetReviewQuery(reviewId), cancellationToken);

                    return review;
                });


            descriptor.Field("removeBook")
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");

                    await context.Service<IMediator>()
                        .Send(new RemoveBookCommand(uint.Parse(id)), cancellationToken);

                    return true;
                });

            descriptor.Field("updateAuthor")
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Argument("input", argument => argument.Type<NonNullType<AuthorInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");
                    var input = context.Argument<AuthorInput>("input");

                    var command = new UpdateAuthorCommand
                    {
                        Id = uint.Parse(id),
                        Name = input.Name.Trim(),
                        Biography = input.Biography.Trim(),
                    };

                    var authorId = await context
                        .Service<IMediator>()
                        .Send(command, cancellationToken);

                    var author = await context
                        .Service<IMediator>()
                        .Send(new GetAuthorQuery(authorId), cancellationToken);

                    return author;
                });

            descriptor.Field("updateBook")
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Argument("input", argument => argument.Type<NonNullType<BookInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");
                    var input = context.Argument<BookInput>("input");

                    var genres = new List<int>(input.Genres.Select(int.Parse).ToList());
                    var authors = new List<int>(input.Authors.Select(int.Parse).ToList());

                    var command = new UpdateBookCommand
                    {
                        Id = uint.Parse(id),
                        Title = input.Title.Trim(),
                        Description = input.Description.Trim(),
                        ISBN = input.ISBN,
                        Genres = genres,
                        Authors = authors,
                    };

                    var bookId = await context
                        .Service<IMediator>()
                        .Send(command, cancellationToken);

                    var book = await context
                        .Service<IMediator>()
                        .Send(new GetBookQuery(bookId), cancellationToken);

                    return book;
                });

            descriptor.Field("updateGenre")
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Argument("input", argument => argument.Type<NonNullType<GenreInputType>>())
                .Resolver(async (context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");
                    var input = context.Argument<GenreInput>("input");

                    var command = new UpdateGenreCommand
                    {
                        Id = uint.Parse(id),
                        Name = input.Name.Trim(),
                    };

                    var genreId = await context
                        .Service<IMediator>()
                        .Send(command, cancellationToken);

                    var author = await context
                        .Service<IMediator>()
                        .Send(new GetGenreQuery(genreId), cancellationToken);

                    return author;
                });
        }
    }
}
