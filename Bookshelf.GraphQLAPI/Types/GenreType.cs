using Bookshelf.Domain;
using GraphQL.Types;

namespace Bookshelf.GraphQLAPI.Types
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Name = "Genre";

            Field(name: "id", genre => genre.Id, type: typeof(IdGraphType));
            Field(name: "name", genre => genre.Name);
        }
    }
}
