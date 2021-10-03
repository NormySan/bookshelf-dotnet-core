using Bookshelf.Domain.Books;
using HotChocolate.Types;

namespace Bookshelf.API.Books
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

            //descriptor.Field("books")
            //    .UsePaging<BookType>()
            //    .Resolver(async (context) =>
            //    {
            //        var database = context.Service<DatabaseContext>();
            //        var author = context.Parent<Author>();

            //        var books = await database.Books.Include(book => book.Authors)
            //            .Where(book => book.Authors.Any(bookAuthor => bookAuthor.AuthorId == author.Id))
            //            .ToListAsync();

            //        return books;
            //    });
        }
    }
}
