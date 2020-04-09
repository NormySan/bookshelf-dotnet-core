using System.Collections.Generic;
using Bookshelf.Domain;

namespace Bookshelf.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> books = new List<Book>();

        public BookRepository()
        {
            books.Add(new Book
            {
                Id = 1,
                Name = "Harry Potter and the Chamber of Secrets",
                ISBN = "9781408855669",
            });

            books.Add(new Book
            {
                Id = 2,
                Name = "Jurassic Park",
                ISBN = "9780345538987",
            });

            books.Add(new Book
            {
                Id = 3,
                Name = "Fantastic Beasts and Where to Find Them",
                ISBN = "9781408708989",
            });

            books.Add(new Book
            {
                Id = 4,
                Name = "Skyward",
                ISBN = "9781473217850",
            });
        }

        public List<Book> GetAll()
        {
            return books;
        }
    }
}
