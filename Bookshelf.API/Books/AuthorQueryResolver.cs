using Bookshelf.Domain.Books;
using HotChocolate.Types;

namespace Bookshelf.API.Books
{
    public class AuthorQueryResolver : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);

            descriptor.Field("author")
                .Type<AuthorType>()
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolve((context) =>
                {
                    var id = context.ArgumentValue<string>("id");

                    return context.Service<IAuthorRepository>().GetByIdAsync(int.Parse(id));
                });

            descriptor.Field("authors")
                .Type<NonNullType<ListType<NonNullType<AuthorType>>>>()
                .Resolve((context) =>
                {
                    return context.Service<IAuthorRepository>().GetAllAsync();
                });
        }
    }
}
