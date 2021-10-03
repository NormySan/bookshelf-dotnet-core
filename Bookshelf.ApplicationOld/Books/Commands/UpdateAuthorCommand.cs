using MediatR;

namespace Bookshelf.ApplicationOld.Books.Commands
{
    public class UpdateAuthorCommand : IRequest<int>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
