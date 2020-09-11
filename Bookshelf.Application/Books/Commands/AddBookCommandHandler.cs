using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Commands
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private DatabaseContext context;

        public AddBookCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var genres = await context.Genres
                .Where(genre => command.Genres.Contains(genre.Id))
                .ToListAsync(cancellationToken);

            var authors = await context.Authors
                .Where(author => command.Authors.Contains(author.Id))
                .ToListAsync(cancellationToken);

            var book = new Book()
            {
                Title = command.Title,
                Description = command.Description,
                ISBN = command.ISBN,
                Genres = new List<BookGenre>(),
                Authors = new List<BookAuthor>(),
            };

            foreach (var author in authors)
            {
                book.Authors.Add(new BookAuthor
                {
                    Author = author,
                    Book = book,
                });
            }

            foreach (var genre in genres)
            {
                book.Genres.Add(new BookGenre
                {
                    Genre = genre,
                    Book = book,
                });
            }

            context.Add(book);
            context.SaveChanges();

            return book.Id;
        }
    }
}
