using Bookshelf.Domain.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.Application.Books.Commands
{
    public class AddBookCommand : IRequest<int>
    {
        public readonly string Title;
        public readonly string Description;
        public readonly string ISBN;
        public readonly DateTime Published;
        public readonly List<int> Genres;
        public readonly List<int> Authors;

        public AddBookCommand(
            string title,
            string description,
            string iSBN,
            DateTime published,
            List<int> genres,
            List<int> authors
        )
        {
            Title = title;
            Description = description;
            ISBN = iSBN;
            Published = published;
            Genres = genres;
            Authors = authors;
        }
    }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IAuthorRepository AuthorRepository;
        private readonly IBookRepository BookRepository;
        private readonly IGenreRepository GenreRepository;

        public AddBookCommandHandler(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository
        )
        {
            AuthorRepository = authorRepository;
            BookRepository = bookRepository;
            GenreRepository = genreRepository;
        }

        public async Task<int> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var authors = await AuthorRepository.GetByIdsAsync(command.Authors.ToArray());
            var genres = await GenreRepository.GetByIdsAsync(command.Genres.ToArray());

            var book = new Book(command.Title, command.ISBN, command.Published);

            book.Authors.AddRange(authors);
            book.Genres.AddRange(genres);

            await BookRepository.Add(book);

            return book.Id;
        }
    }
}
