using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Queries
{
    public class GetGenresByBookIdsQuery : IRequest<Dictionary<int, List<Genre>>>
    {
        public IEnumerable<int> BookIds { get; }

        public GetGenresByBookIdsQuery(IEnumerable<int> bookIds)
        {
            BookIds = bookIds;
        }
    }

    public class GetGenresByBookIdsQueryHandler : IRequestHandler<GetGenresByBookIdsQuery, Dictionary<int, List<Genre>>>
    {
        private DatabaseContext Context;

        public GetGenresByBookIdsQueryHandler(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<Dictionary<int, List<Genre>>> Handle(GetGenresByBookIdsQuery request, CancellationToken cancellationToken)
        {
            var booksWithGenres = await Context.Books
                .Where(b => request.BookIds.Contains(b.Id))
                .Select(b => new
                {
                    BookId = b.Id,
                    Genres = b.Genres.Select(bg => bg.Genre),
                })
                .ToListAsync(cancellationToken);

            var result = new Dictionary<int, List<Genre>>();

            foreach (var item in booksWithGenres)
            {
                result.Add(item.BookId, item.Genres.ToList());
            }

            return result;
        }
    }
}
