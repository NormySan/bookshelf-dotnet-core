using Bookshelf.ApplicationOld.Common;
using HotChocolate.Language;
using HotChocolate.Types;
using System;

namespace Bookshelf.ApplicationOld.GraphQL.Scalars
{
    public class ISBNType : ScalarType
    {
        public override Type ClrType { get; } = typeof(string);

        private readonly ISBNValidator validator;

        public ISBNType(ISBNValidator validator) : base("ISBN")
        {
            this.validator = validator;

            Description = "An ISBN 10 or 13 as a string value.";
        }

        public override bool IsInstanceOfType(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            return literal is StringValueNode || literal is NullValueNode;
        }

        public override object ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is StringValueNode stringLiteral)
            {
                return stringLiteral.Value;
            }

            if (literal is NullValueNode)
            {
                return null;
            }

            throw new ArgumentException(
                "The ISBN scalar type can only parse string literals.",
                nameof(literal)
            );
        }

        public override IValueNode ParseValue(object value)
        {
            if (value == null)
            {
                return new NullValueNode(null);
            }

            if (value is string s)
            {
                return new StringValueNode(null, s, false);
            }

            throw new ArgumentException(
                "The specified value has to be a string in order " +
                "to be parsed by the ISBN scalar type."
            );
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

            throw new ArgumentException("The specified value cannot be serialized.");
        }

        public override bool TryDeserialize(object serialized, out object value)
        {
            if (serialized is null)
            {
                value = null;
                return true;
            }

            if (serialized is string stringValue)
            {
                value = stringValue;
                return true;
            }

            value = null;
            return false;
        }
    }
}
