using System.Collections.Generic;

namespace Bookshelf.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public List<BookAuthor> Books;
    }
}
