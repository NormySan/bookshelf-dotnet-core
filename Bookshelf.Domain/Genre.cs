using System.Collections.Generic;

namespace Bookshelf.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<BookGenre> Books { get; set; }
    }
}
