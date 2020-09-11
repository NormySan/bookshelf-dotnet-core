using GraphQL.Types;
using System.Collections.Generic;

namespace Bookshelf.GraphQLAPI.Input
{
    public class BookInput
    {
        public string title { get; set; }
        public string description { get; set; }
        public string isbn { get; set; }
        public List<string> genres { get; set; }
        public List<string> authors { get; set; }
    }

    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "BookInput";

            Field<NonNullGraphType<StringGraphType>>(
                name: "title",
                description: "The title of the book."
            );

            Field<NonNullGraphType<StringGraphType>>(
                name: "description",
                description: "A description of the book."
            );

            Field<NonNullGraphType<StringGraphType>>(
                name: "isbn",
                description: "Unique ISBN number of the book. Must be either a ISBN 10 or 13 and may only contain numbers."
            );

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>(
                name: "genres",
                description: "A list of genres."
            );

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>(
                name: "authors",
                description: "A list of authors"
            );
        }
    }
}
