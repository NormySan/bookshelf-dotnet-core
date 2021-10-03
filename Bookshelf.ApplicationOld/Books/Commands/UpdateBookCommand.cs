using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class UpdateBookCommand : IRequest<int>
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public List<int> Genres { get; set; }
        public List<int> Authors { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private DatabaseContext Context { get; }

        public UpdateBookCommandHandler(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await Context.Books
                .Include(book => book.Authors)
                .Include(book => book.Genres)
                .SingleAsync(book => book.Id == command.Id);

            var genres = await Context.Genres
                .Where(genre => command.Genres.Contains(genre.Id))
                .ToListAsync(cancellationToken);

            var authors = await Context.Authors
                .Where(author => command.Authors.Contains(author.Id))
                .ToListAsync(cancellationToken);

            book.Title = command.Title;
            book.Description = command.Description;
            book.ISBN = command.ISBN;

            book.Authors = new List<BookAuthor>();
            book.Genres = new List<BookGenre>();

            foreach (var author in authors)
            {
                book.Authors.Add(new BookAuthor
                {
                    Book = book,
                    Author = author,
                });
            }

            foreach (var genre in genres)
            {
                book.Genres.Add(new BookGenre
                {
                    Book = book,
                    Genre = genre,
                });
            }

            await Context.SaveChangesAsync();

            return book.Id;
        }
    }
}
