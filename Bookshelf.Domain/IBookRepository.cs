using System.Collections.Generic;

namespace Bookshelf.Domain
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
    }
}
