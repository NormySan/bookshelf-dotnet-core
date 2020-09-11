using Bookshelf.Application.Books.Commands;
using Bookshelf.Application.Books.Queries;
using Bookshelf.GraphQLAPI.Input;
using Bookshelf.GraphQLAPI.Types;
using GraphQL;
using GraphQL.Types;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.GraphQLAPI
{
    public class GraphQLAPIMutation : ObjectGraphType
    {
        public GraphQLAPIMutation(IMediator mediator)
        {
            FieldAsync<AuthorType>(
                name: "addAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "input" }
                ),
                resolve: async context =>
                {
                    var input = context.GetArgument<AuthorInput>("input");

                    var id = await mediator.Send(new AddAuthorCommand
                    {
                        Name = input.name,
                        Biography = input.biography,
                    }, context.CancellationToken);

                    var author = await mediator.Send(new GetAuthorQuery(id), context.CancellationToken);

                    return author;
                }
            );

            FieldAsync<BookType>(
                name: "addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "input" }
                ),
                resolve: async context =>
                {
                    var input = context.GetArgument<BookInput>("input");

                    var genres = new List<int>(input.genres.Select(int.Parse).ToList());
                    var authors = new List<int>(input.authors.Select(int.Parse).ToList());

                    var id = await mediator.Send(new AddBookCommand
                    {
                        Title = input.title,
                        Description = input.description,
                        ISBN = input.isbn,
                        Genres = genres,
                        Authors = authors,
                    }, context.CancellationToken);

                    var book = await mediator.Send(new GetBookQuery(id), context.CancellationToken);

                    return book;
                }
            );

            FieldAsync<GenreType>(
                name: "addGenre",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GenreInputType>> { Name = "input" }
                ),
                resolve: async context =>
                {
                    var input = context.GetArgument<GenreInput>("input");

                    var id = await mediator.Send(
                        new AddGenreCommand
                        {
                            Name = input.name,
                        },
                        context.CancellationToken
                    );

                    var genre = await mediator.Send(new GetGenreQuery(id), context.CancellationToken);

                    return genre;
                }
            );
        }
    }
}
