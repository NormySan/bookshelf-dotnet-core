using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, int>
    {
        private DatabaseContext Context { get; }

        public AddAuthorCommandHandler(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<int> Handle(AddAuthorCommand command, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = command.Name,
                Biography = command.Biography,
            };

            Context.Add(author);
            await Context.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
