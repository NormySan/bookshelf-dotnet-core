using System.Collections.Generic;

namespace Bookshelf.Domain.Books
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }

        private List<Book> Books { get; set; }
    }
}
