using MediatR;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class AddGenreCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
