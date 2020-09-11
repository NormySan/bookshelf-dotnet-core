using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace Bookshelf.GraphQLAPI
{
    public class GraphQLAPISchema : Schema
    {
        public GraphQLAPISchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<GraphQLAPIQuery>();
            Mutation = provider.GetRequiredService<GraphQLAPIMutation>();
        }
    }
}
