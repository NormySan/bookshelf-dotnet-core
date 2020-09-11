using GraphQL.Types;

namespace Bookshelf.GraphQLAPI.Types
{
    public class GenreInputType : InputObjectGraphType
    {
        public GenreInputType()
        {
            Name = "GenreInput";

            Field<NonNullGraphType<StringGraphType>>(
                name: "name",
                description: "The name of the genre."
            );
        }
    }
}
