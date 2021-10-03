using System;
using System.Collections.Generic;

namespace Bookshelf.Domain.Books
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } = "";

        public string ISBN { get; set; }

        public int Pages { get; set; } = 0;

        public DateTime Published { get; set; }

        public List<Author> Authors { get; set; }

        public List<Genre> Genres { get; set; }

        public Book(string title, string iSBN, DateTime published)
        {
            Title = title;
            ISBN = iSBN;
            Published = published;

            Authors = new List<Author>();
            Genres = new List<Genre>();
        }
    }
}
