using Bookshelf.GraphQLAPI.Types;
using Bookshelf.Infrastructure;
using GraphQL;
using GraphQL.Types;
using System.Linq;

namespace Bookshelf.GraphQLAPI
{
    public class GraphQLAPIQuery : ObjectGraphType
    {
        public GraphQLAPIQuery(DatabaseContext database)
        {
            Name = "Query";

            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>() { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return database.Authors.Single(author => author.Id == int.Parse(id));
                }
            );

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context =>
                {
                    return database.Authors.ToList();
                }
            );

            Field<BookType>(
                name: "book",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>() { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return database.Books.Single(book => book.Id == int.Parse(id));
                }
            );

            Field<ListGraphType<BookType>>(
                name: "books",
                resolve: context =>
                {
                    return database.Books.ToList();
                }
            );

            Field<GenreType>(
                name: "genre",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>() { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return database.Genres.Single(genre => genre.Id == int.Parse(id));
                }
            );

            Field<ListGraphType<GenreType>>(
                name: "genres",
                resolve: context =>
                {
                    return database.Genres.ToList();
                }
            );
        }
    }
}
