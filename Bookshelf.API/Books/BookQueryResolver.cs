using Bookshelf.Domain.Books;
using HotChocolate.Types;

namespace Bookshelf.API.Books
{
    public class BookQueryResolver : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);

            descriptor.Field("book")
                .Type<BookType>()
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolve((context) =>
                {
                    var id = context.ArgumentValue<string>("id");

                    return context.Service<IBookRepository>().GetByIdAsync(int.Parse(id));
                });

            descriptor.Field("books")
                .Type<NonNullType<ListType<NonNullType<BookType>>>>()
                .Resolve((context) =>
                {
                    return context.Service<IBookRepository>().GetAllAsync();
                });
        }
    }
}
