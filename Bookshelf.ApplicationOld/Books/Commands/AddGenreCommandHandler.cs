using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, int>
    {
        private DatabaseContext Context;

        public AddGenreCommandHandler(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(AddGenreCommand command, CancellationToken cancellationToken)
        {
            var genre = new Genre()
            {
                Name = command.Name
            };

            Context.Add(genre);
            await Context.SaveChangesAsync(cancellationToken);

            return genre.Id;
        }
    }
}
