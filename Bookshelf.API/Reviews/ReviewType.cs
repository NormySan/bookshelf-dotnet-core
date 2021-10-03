using Bookshelf.Domain.Reviews;
using HotChocolate.Types;

namespace Bookshelf.API.Reviews
{
    public class ReviewType : ObjectType<Review>
    {
        protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(review => review.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(review => review.Content)
                .Type<NonNullType<StringType>>();
        }
    }
}
