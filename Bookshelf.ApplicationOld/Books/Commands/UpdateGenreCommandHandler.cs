using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, int>
    {
        private DatabaseContext Context { get; }

        public UpdateGenreCommandHandler(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
        {
            var genre = await Context.Genres.SingleAsync(genre => genre.Id == command.Id);

            genre.Name = command.Name;

            await Context.SaveChangesAsync();

            return genre.Id;
        }
    }
}
