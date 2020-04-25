using Bookshelf.Domain;
using GraphQL.Types;

namespace Bookshelf.GraphQLAPI.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";

            Field(name: "id", author => author.Id, type: typeof(IdGraphType));
            Field(name: "name", author => author.Name);
            Field(name: "biography", author => author.Biography);
        }
    }
}
