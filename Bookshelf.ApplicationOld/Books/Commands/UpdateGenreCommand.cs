using MediatR;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class UpdateGenreCommand : IRequest<int>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
    }
}
