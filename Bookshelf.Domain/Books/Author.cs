using System.Collections.Generic;

namespace Bookshelf.Domain.Books
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Biography { get; set; } = null;

        // This needs to be here because of Entity Framework. Remove when
        // shadow navigation is possible with many-to-many relationships.
        private readonly List<Book> Books = new List<Book>();

        public Author(string name)
        {
            Name = name;
        }
    }
}
