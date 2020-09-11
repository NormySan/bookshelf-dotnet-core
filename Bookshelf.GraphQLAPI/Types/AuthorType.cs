using Bookshelf.Domain;
using Bookshelf.GraphQLAPI.Loaders;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace Bookshelf.GraphQLAPI.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IDataLoaderContextAccessor accessor, BookLoader bookLoader)
        {
            Name = "Author";

            Field(name: "id", author => author.Id, type: typeof(IdGraphType));
            Field(name: "name", author => author.Name);
            Field(name: "biography", author => author.Biography);

            Field<ListGraphType<BookType>>(
                name: "books",
                resolve: context =>
                {
                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Book>(
                        "GetBooksByAuthorId",
                        bookLoader.GetBooksByAuthorIds
                    );

                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}
