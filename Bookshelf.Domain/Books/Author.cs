using System.Collections.Generic;

namespace Bookshelf.Domain.Books
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Biography { get; set; } = null;

        private List<Book> Books { get; set; }

        public Author(string name)
        {
            Name = name;
        }
    }
}
