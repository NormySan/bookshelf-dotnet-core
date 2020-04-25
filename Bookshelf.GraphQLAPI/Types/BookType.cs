using Bookshelf.Domain;
using Bookshelf.Infrastructure;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.GraphQLAPI.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        private DatabaseContext Database;

        public BookType(DatabaseContext database, IDataLoaderContextAccessor accessor)
        {
            Database = database;

            Name = "Book";

            Field(name: "id", book => book.Id, type: typeof(IdGraphType));
            Field(name: "title", book => book.Title);
            Field(name: "description", book => book.Description);
            Field(name: "isbn", book => book.ISBN);

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context =>
                {
                    var id = context.Source.Id;

                    var query = from author in database.Set<Author>()
                                join bookAuthor in database.Set<BookAuthor>()
                                    on author.Id equals bookAuthor.AuthorId
                                where bookAuthor.BookId == id
                                select author;

                    return query.ToList();
                }
            );

            FieldAsync<ListGraphType<GenreType>, List<Genre>>(
                name: "genres",
                resolve: context =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, List<Genre>>("GetGenresByBookIds", GetGenresByBookIds);
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }

        private async Task<IDictionary<int, List<Genre>>> GetGenresByBookIds(IEnumerable<int> bookIds)
        {
            var booksWithGenres = Database.Books
                .Where(b => bookIds.Contains(b.Id))
                .Select(b => new
                {
                    BookId = b.Id,
                    Genres = b.Genres.Select(bg => bg.Genre),
                });

            var result = new Dictionary<int, List<Genre>>();

            foreach (var item in booksWithGenres)
            {
                result.Add(item.BookId, item.Genres.ToList());
            }

            return result;
        }


    }
}
