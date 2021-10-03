using HotChocolate.Types;

namespace Bookshelf.ApplicationOld.GraphQL.Input
{
    public class GenreInput
    {
        public string Name { get; set; }
    }

    public class GenreInputType : InputObjectType<GenreInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<GenreInput> descriptor)
        {
            descriptor.Field(input => input.Name)
                .Type<NonNullType<StringType>>()
                .Description("The name of the genre");
        }
    }
}
