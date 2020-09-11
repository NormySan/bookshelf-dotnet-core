using Bookshelf.Application.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bookshelf.Tests
{
    [TestClass]
    public class ISBNValidatorTest
    {
        private ISBNValidator Validator;

        public ISBNValidatorTest()
        {
            Validator = new ISBNValidator();
        }

        [TestMethod]
        public void IsValidIsbn_WhenLengthIsNotSupported_ShouldThrowException()
        {
            Assert.ThrowsException<System.ArgumentException>(
                () => Validator.IsValidIsbn10("stringThatIsMuchToLong"),
                "The ISBN string to validate must be 10 or 13 characters in length."
            );
        }

        [TestMethod]
        public void IsValidIsbn10_WhenLengthIsNot10_ShouldThrowException()
        {
            Assert.ThrowsException<System.ArgumentException>(
                () => Validator.IsValidIsbn10("stringThatIsToLong"),
                "The ISBN string to validate must be 10 characters in length and may only contain numbers."
            );
        }

        [TestMethod]
        public void IsValidIsbn10_WhenStringIsNotNumeric_ShouldThrowException()
        {
            Assert.ThrowsException<System.ArgumentException>(
                () => Validator.IsValidIsbn10("abcdefghij"),
                "The ISBN string to validate must be 10 characters in length and may only contain numbers."
            );
        }

        [TestMethod]
        public void IsValidIsbn10_WhenISBNIsValid_ShouldReturnTrue()
        {
            Assert.IsTrue(Validator.IsValidIsbn10("0439064864"));
            Assert.IsTrue(Validator.IsValidIsbn10("0716703440"));
            Assert.IsTrue(Validator.IsValidIsbn10("0399555811"));
            Assert.IsTrue(Validator.IsValidIsbn10("1476733953"));
            Assert.IsTrue(Validator.IsValidIsbn10("0307887448"));
        }

        [TestMethod]
        public void IsValidIsbn10_WhenISBNIsNotValid_ShouldReturnFalse()
        {
            Assert.IsFalse(Validator.IsValidIsbn10("1013657890"));
            Assert.IsFalse(Validator.IsValidIsbn10("9476936598"));
            Assert.IsFalse(Validator.IsValidIsbn10("8375018575"));
            Assert.IsFalse(Validator.IsValidIsbn10("9846203785"));
        }

        [TestMethod]
        public void IsValidIsbn13_WhenLengthIsNot13_ShouldThrowException()
        {
            Assert.ThrowsException<System.ArgumentException>(
                () => Validator.IsValidIsbn13("stringThatIsEvenLonger"),
                "The ISBN string to validate must be 13 characters in length and may only contain numbers."
            );
        }

        [TestMethod]
        public void IsValidIsbn13_WhenStringIsNotNumeric_ShouldThrowException()
        {
            Assert.ThrowsException<System.ArgumentException>(
                () => Validator.IsValidIsbn13("abcdefghij"),
                "The ISBN string to validate must be 13 characters in length and may only contain numbers."
            );
        }

        [TestMethod]
        public void IsValidIsbn13_WhenISBNIsValid_ShouldReturnTrue()
        {
            Assert.IsTrue(Validator.IsValidIsbn13("9780307887443"));
        }

        [TestMethod]
        public void IsValidIsbn13_WhenISBNIsNotValid_ShouldReturnFalse()
        {
            Assert.IsFalse(Validator.IsValidIsbn13("3610473623927"));
            Assert.IsFalse(Validator.IsValidIsbn13("9026732950173"));
            Assert.IsFalse(Validator.IsValidIsbn13("1093067482028"));
            Assert.IsFalse(Validator.IsValidIsbn13("1983746404382"));
        }
    }
}
