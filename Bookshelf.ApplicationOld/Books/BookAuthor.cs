﻿namespace Bookshelf.ApplicationOld.Books
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
