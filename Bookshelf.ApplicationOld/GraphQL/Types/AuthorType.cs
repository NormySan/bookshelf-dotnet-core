using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bookshelf.ApplicationOld.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(author => author.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(author => author.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(author => author.Biography)
                .Type<NonNullType<StringType>>();

            descriptor.Field("books")
                .UsePaging<BookType>()
                .Resolver(async (context) =>
                {
                    var database = context.Service<DatabaseContext>();
                    var author = context.Parent<Author>();

                    var books = await database.Books.Include(book => book.Authors)
                        .Where(book => book.Authors.Any(bookAuthor => bookAuthor.AuthorId == author.Id))
                        .ToListAsync();

                    return books;
                });
        }
    }
}
