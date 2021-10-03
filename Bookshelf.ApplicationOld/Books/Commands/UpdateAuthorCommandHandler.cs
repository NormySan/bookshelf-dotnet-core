using Bookshelf.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
    {
        private DatabaseContext Context { get; }

        public UpdateAuthorCommandHandler(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = await Context.Authors.SingleAsync(author => author.Id == command.Id);

            author.Name = command.Name;
            author.Biography = command.Biography;

            await Context.SaveChangesAsync();

            return author.Id;
        }
    }
}
