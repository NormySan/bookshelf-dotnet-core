using MediatR;

namespace Bookshelf.Application.Books.Commands
{
    public class AddAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
