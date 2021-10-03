using MediatR;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class AddAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
