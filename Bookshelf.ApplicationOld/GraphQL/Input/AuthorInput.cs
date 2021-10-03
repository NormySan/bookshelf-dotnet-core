using HotChocolate.Types;

namespace Bookshelf.ApplicationOld.GraphQL.Input
{
    public class AuthorInput
    {
        public string Name { get; set; }
        public string Biography { get; set; }
    }

    public class AuthorInputType : InputObjectType<AuthorInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AuthorInput> descriptor)
        {
            descriptor.Field(input => input.Name)
                .Type<NonNullType<StringType>>()
                .Description("The name of the autor.");

            descriptor.Field(input => input.Biography)
                .Type<NonNullType<StringType>>()
                .Description("A biography for the autor.");
        }
    }
}
