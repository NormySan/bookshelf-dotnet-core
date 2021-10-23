namespace Bookshelf.Domain.Books
{
    public class SeriesBook
    {
        public int Id;

        public int BookId;

        public int Order;

        public string Name;

        public SeriesBook(int bookId, string name)
        {
            BookId = bookId;
            Name = name;
        }
    }
}
