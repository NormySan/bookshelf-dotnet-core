using MediatR;

namespace Bookshelf.Application.Books.Commands
{
    public class AddGenreCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
