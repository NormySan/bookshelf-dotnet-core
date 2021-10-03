using Bookshelf.ApplicationOld.Books.Queries;
using Bookshelf.ApplicationOld.Reviews.Queries;
using HotChocolate.Types;
using MediatR;

namespace Bookshelf.ApplicationOld.GraphQL.Types
{
    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("author")
                .Type<AuthorType>()
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolver((context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");

                    return context.Service<IMediator>()
                        .Send(new GetAuthorQuery(int.Parse(id)), cancellationToken);
                });

            descriptor.Field("authors")
                .Type<NonNullType<ListType<NonNullType<AuthorType>>>>()
                .Resolver((context, cancellationToken) =>
                {
                    return context.Service<IMediator>()
                        .Send(new GetAuthorsQuery(), cancellationToken);
                });

            descriptor.Field("book")
                .Type<BookType>()
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolver((context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");

                    return context.Service<IMediator>()
                        .Send(new GetBookQuery(int.Parse(id)), cancellationToken);
                });

            descriptor.Field("books")
                .Type<NonNullType<ListType<NonNullType<BookType>>>>()
                .Resolver((context, cancellationToken) =>
                {
                    return context.Service<IMediator>()
                        .Send(new GetBooksQuery(), cancellationToken);
                });

            descriptor.Field("genre")
                .Type<GenreType>()
                .Argument("id", d => d.Type<NonNullType<IdType>>())
                .Resolver((context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");

                    return context.Service<IMediator>()
                        .Send(new GetGenreQuery(int.Parse(id)), cancellationToken);
                });

            descriptor.Field("genres")
                .Type<NonNullType<ListType<NonNullType<GenreType>>>>()
                .Resolver((context, cancellationToken) =>
                {
                    return context.Service<IMediator>()
                        .Send(new GetGenresQuery(), cancellationToken);
                });

            descriptor.Field("review")
                .Type<ReviewType>()
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolver((context, cancellationToken) =>
                {
                    var id = context.Argument<string>("id");

                    return context.Service<IMediator>()
                        .Send(new GetReviewQuery(int.Parse(id)), cancellationToken);
                });
        }
    }
}