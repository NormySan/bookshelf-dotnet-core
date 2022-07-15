using System.Collections.Generic;

namespace Bookshelf.Domain.Series
{
    public class Series
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SeriesBook> Books { get; set; }

        public Series(string name)
        {
            Name = name;
            Books = new List<SeriesBook>();
        }
    }
}
