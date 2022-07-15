using System.Collections.Generic;

namespace Bookshelf.Domain.Books
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // This needs to be here because of Entity Framework. Remove when
        // shadow navigation is possible with many-to-many relationships.
        private readonly List<Book> Books = new List<Book>();

        public Genre(string name)
        {
            Name = name;
        }
    }
}
