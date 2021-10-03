using Bookshelf.Domain.Books;
using HotChocolate.Types;

namespace Bookshelf.API.Books
{
    public class GenreType : ObjectType<Genre>
    {
        protected override void Configure(IObjectTypeDescriptor<Genre> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(genre => genre.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(genre => genre.Name)
                .Type<NonNullType<StringType>>();
        }
    }
}
