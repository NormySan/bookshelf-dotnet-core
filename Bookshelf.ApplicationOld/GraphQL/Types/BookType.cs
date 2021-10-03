using Bookshelf.ApplicationOld.GraphQL.Loaders;
using Bookshelf.ApplicationOld.GraphQL.Scalars;
using Bookshelf.ApplicationOld.Reviews.Queries;
using Bookshelf.Domain;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using MediatR;
using System;
using System.Linq;

namespace Bookshelf.ApplicationOld.GraphQL.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(book => book.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(book => book.Title)
                .Type<NonNullType<StringType>>();

            descriptor.Field(book => book.Description)
                .Type<NonNullType<StringType>>();

            descriptor.Field(book => book.ISBN)
                .Name("isbn")
                .Type<NonNullType<ISBNType>>();

            descriptor.Field("rating")
                .Type<NonNullType<FloatType>>()
                .Resolver(async (context, cancellationToken) =>
                {
                    var book = context.Parent<Book>();

                    var rating = await context.DataLoader<BookRatingsLoader>()
                        .LoadAsync(book.Id, cancellationToken);

                    return Math.Round(rating, 1);
                });

            descriptor.Field("authors")
                .Type<NonNullType<ListType<NonNullType<AuthorType>>>>()
                .Resolver(context =>
                {
                    var book = context.Parent<Book>();

                    return book.Authors
                        .Select(author => author.Author)
                        .ToList();
                });

            descriptor.Field("genres")
                .Type<NonNullType<ListType<NonNullType<GenreType>>>>()
                .Resolver(context =>
                {
                    var book = context.Parent<Book>();

                    return book.Genres
                        .Select(genre => genre.Genre)
                        .ToList();
                });

            descriptor.Field("reviews")
                .Type<NonNullType<ListType<NonNullType<ReviewType>>>>()
                .Resolver((context, cancellationToken) =>
                {
                    var book = context.Parent<Book>();

                    return context.Service<IMediator>()
                        .Send(new GetReviewsForBookQuery(book.Id), cancellationToken);
                });
        }
    }
}
