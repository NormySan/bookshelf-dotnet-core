using System.Collections.Generic;

namespace Bookshelf.ApplicationOld.Books
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public List<Genre> Genres { get; set; }

        public List<BookAuthor> Authors { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
