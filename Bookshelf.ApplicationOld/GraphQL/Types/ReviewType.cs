using Bookshelf.Domain;
using HotChocolate.Types;

namespace Bookshelf.ApplicationOld.GraphQL.Types
{
    public class ReviewType : ObjectType<Review>
    {
        protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(review => review.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(review => review.Rating)
                .Type<NonNullType<IntType>>();

            descriptor.Field(review => review.Content)
                .Type<StringType>();
        }
    }
}
