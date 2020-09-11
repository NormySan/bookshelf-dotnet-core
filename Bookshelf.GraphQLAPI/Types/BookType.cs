using Bookshelf.Domain;
using GraphQL.Types;
using System.Linq;

namespace Bookshelf.GraphQLAPI.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";

            Field(name: "id", book => book.Id, type: typeof(IdGraphType));
            Field(name: "title", book => book.Title);
            Field(name: "description", book => book.Description);
            Field(name: "isbn", book => book.ISBN);

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context =>
                {
                    return context.Source.Authors
                        .Select(bookAuthor => bookAuthor.Author)
                        .ToList();
                }
            );

            Field<ListGraphType<GenreType>>(
                name: "genres",
                resolve: context =>
                {
                    return context.Source.Genres
                        .Select(bookGenre => bookGenre.Genre)
                        .ToList();
                }
            );
        }
    }
}
