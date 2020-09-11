using MediatR;
using System.Collections.Generic;

namespace Bookshelf.Application.Books.Commands
{
    public class AddBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public List<int> Genres { get; set; }
        public List<int> Authors { get; set; }
    }
}
