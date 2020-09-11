using GraphQL.Types;

namespace Bookshelf.GraphQLAPI.Types
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "AuthorInput";

            Field<NonNullGraphType<StringGraphType>>(
                name: "name",
                description: "The name of the author."
            );

            Field<NonNullGraphType<StringGraphType>>(
                name: "biography",
                description: "The authors biography."
            );
        }
    }
}
