namespace Bookshelf.Domain.Books
{
    public class SeriesBook
    {
        public int Id { get; set; }

        public int BookId { get; }

        public int Order { get; }

        public SeriesBook(int bookId, int order)
        {
            BookId = bookId;
            Order = order;
        }
    }
}
