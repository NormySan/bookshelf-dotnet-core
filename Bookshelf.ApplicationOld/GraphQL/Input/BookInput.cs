using HotChocolate.Types;
using System.Collections.Generic;

namespace Bookshelf.ApplicationOld.GraphQL.Input
{
    public class BookInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Authors { get; set; }
    }

    public class BookInputType : InputObjectType<BookInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<BookInput> descriptor)
        {
            descriptor.Field(input => input.Title)
                .Type<NonNullType<StringType>>()
                .Description("The title of the book.");

            descriptor.Field(input => input.Description)
                .Type<NonNullType<StringType>>()
                .Description("A description of the book.");

            descriptor.Field(input => input.ISBN)
                .Name("isbn")
                .Type<NonNullType<StringType>>()
                .Description("Unique ISBN number of the book. Must be either a ISBN 10 or 13 and may only contain numbers.");

            descriptor.Field(input => input.Genres)
                .Type<NonNullType<ListType<NonNullType<IdType>>>>()
                .Description("A list of genres.");

            descriptor.Field(input => input.Authors)
                .Type<NonNullType<ListType<NonNullType<IdType>>>>()
                .Description("A list of authors.");
        }
    }
}
