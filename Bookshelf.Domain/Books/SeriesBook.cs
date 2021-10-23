namespace Bookshelf.Domain.Books
{
    public class SeriesBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int Order { get; set; }

        public SeriesBook(int bookId, int order)
        {
            BookId = bookId;
            Order = order;
        }
    }
}
