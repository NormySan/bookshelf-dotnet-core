using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bookshelf.ApplicationOld.Common
{
    public class ISBNValidator
    {
        public bool isValidIsbn(string isbn)
        {
            if (isbn.Length == 10)
            {
                return IsValidIsbn10(isbn);
            }

            if (isbn.Length == 13)
            {
                return IsValidIsbn13(isbn);
            }

            throw new ArgumentException("The ISBN string to validate must be 10 or 13 characters in length.");
        }

        public bool IsValidIsbn10(string isbn)
        {
            var regex = new Regex(@"^\d{10}$");

            if (regex.IsMatch(isbn) == false)
            {
                throw new ArgumentException("The ISBN string to validate must be 10 characters in length and may only contain numbers.");
            }

            var sums = new int[10];

            for (int i = 0; i < isbn.Length; i++)
            {
                var position = 10 - i;

                sums[i] = int.Parse(isbn[i].ToString()) * position;
            }

            var dividend = sums.Sum();
            var divisor = 11;

            var quotient = dividend / divisor;
            var remainder = dividend - (quotient * divisor);

            return remainder == 0;
        }

        public bool IsValidIsbn13(string isbn)
        {
            var regex = new Regex(@"^\d{13}$");

            if (regex.IsMatch(isbn) == false)
            {
                throw new ArgumentException("The ISBN string to validate must be 13 characters in length and may only contain numbers.");
            }

            var sums = new int[13];

            for (int i = 0; i < isbn.Length; i++)
            {
                var position = 13 - i;
                var isEvenPosition = position % 2 == 0;

                if (isEvenPosition)
                {
                    sums[i] = int.Parse(isbn[i].ToString()) * 3;
                }
                else
                {
                    sums[i] = int.Parse(isbn[i].ToString()) * 1;
                }
            }

            var dividend = sums.Sum();
            var divisor = 10;

            var quotient = dividend / divisor;
            var remainder = dividend - (quotient * divisor);

            return remainder == 0;
        }
    }
}
