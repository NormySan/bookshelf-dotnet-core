using GraphQL.Language.AST;
using GraphQL.Types;
using System;

namespace Bookshelf.GraphQLAPI.Scalars
{
    public class ISBNScalar : ScalarGraphType
    {
        public ISBNScalar()
        {
            Name = "ISBN";
            Description = "A ISBN 10 or 13 string value.";
        }

        public override object ParseLiteral(IValue value)
        {
            return value is StringValue stringValue
                ? stringValue
                : null;
        }

        public override object ParseValue(object value)
        {
            if (value == null)
            {
                return value;
            }

            if (value is string s)
            {
                return s;
            }

            throw new ArgumentException("ISBN must be a string.");
        }

        public override object Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is string s)
            {
                return s;
            }

            throw new ArgumentException("ISBN must be a string.");
        }
    }
}
