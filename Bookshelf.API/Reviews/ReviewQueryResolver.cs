using HotChocolate.Types;

namespace Bookshelf.API.Reviews
{
    public class ReviewQueryResolver : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name(OperationTypeNames.Query);

            descriptor.Field("review")
                .Type<ReviewType>()
                .Argument("id", argument => argument.Type<NonNullType<IdType>>())
                .Resolve((context) =>
                {
                    var id = context.ArgumentValue<string>("id");

                    return null;
                });
        }
    }
}
