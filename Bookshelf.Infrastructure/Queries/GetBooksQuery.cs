using Bookshelf.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Infrastructure.Queries
{
    class GetBooksQuery
    {
        private DatabaseContext context;

        public GetBooksQuery(DatabaseContext context)
        {
            this.context = context;
        }

        public List<Book> Execute()
        {
            return context.Books.ToList();
        }
    }
}
