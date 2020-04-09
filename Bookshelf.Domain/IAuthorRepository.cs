using System.Collections.Generic;

namespace Bookshelf.Domain
{
    public interface IAuthorRepository
    {
        public List<Author> GetAll();
    }
}
