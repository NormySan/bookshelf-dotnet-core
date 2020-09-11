using Bookshelf.Application.Books.Queries;
using Bookshelf.GraphQLAPI.Types;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace Bookshelf.GraphQLAPI
{
    public class GraphQLAPIQuery : ObjectGraphType
    {
        public GraphQLAPIQuery(IMediator mediator)
        {
            Name = "Query";

            FieldAsync<AuthorType>(
                name: "author",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>() { Name = "id" }
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");

                    return await mediator.Send(new GetAuthorQuery(int.Parse(id)), context.CancellationToken);
                }
            );

            FieldAsync<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: async context =>
                {
                    return await mediator.Send(new GetAuthorsQuery(), context.CancellationToken);
                }
            );

            FieldAsync<BookType>(
                name: "book",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");

                    return await mediator.Send(new GetBookQuery(int.Parse(id)), context.CancellationToken);
                }
            );

            FieldAsync<ListGraphType<BookType>>(
                name: "books",
                resolve: async context =>
                {
                    return await mediator.Send(new GetBooksQuery(), context.CancellationToken);
                }
            );

            FieldAsync<GenreType>(
                name: "genre",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");

                    return await mediator.Send(new GetGenreQuery(int.Parse(id)), context.CancellationToken);
                }
            );

            FieldAsync<ListGraphType<GenreType>>(
                name: "genres",
                resolve: async context =>
                {
                    return await mediator.Send(new GetGenresQuery(), context.CancellationToken);
                }
            );
        }
    }
}
