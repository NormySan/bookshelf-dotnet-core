using System.Collections.Generic;

namespace Bookshelf.Domain
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public string ISBN { get; set; }

        public List<BookGenre> Genres { get; set; }

        public List<BookAuthor> Authors { get; set; }
    }
}
