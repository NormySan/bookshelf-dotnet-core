using Bookshelf.Domain;
using HotChocolate.Types;

namespace Bookshelf.ApplicationOld.GraphQL.Types
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
