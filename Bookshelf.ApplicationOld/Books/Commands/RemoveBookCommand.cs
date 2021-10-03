using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class RemoveBookCommand : IRequest<int>
    {
        public uint Id { get; }

        public RemoveBookCommand(uint id)
        {
            Id = id;
        }
    }

    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, int>
    {
        private DatabaseContext context;

        public RemoveBookCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(RemoveBookCommand command, CancellationToken cancellationToken)
        {
            var book = await context.Books
                .Include(book => book.Authors)
                .Include(book => book.Genres)
                .SingleAsync(book => book.Id == command.Id, cancellationToken);

            context.Remove(book);
            await context.SaveChangesAsync();

            return book.Id;
        }
    }
}
