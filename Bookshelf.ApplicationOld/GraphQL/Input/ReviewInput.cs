using HotChocolate.Types;

namespace Bookshelf.ApplicationOld.GraphQL.Input
{
    public class ReviewInput
    {
        public string Content { get; set; }
        public int Rating { get; set; }
    }

    public class ReviewInputType : InputObjectType<ReviewInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ReviewInput> descriptor)
        {
            descriptor.Field(input => input.Content)
                .Type<StringType>();

            descriptor.Field(input => input.Rating)
                .Type<NonNullType<IntType>>()
                .Description("A rating between 1 and 5.");
        }
    }
}
