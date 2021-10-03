using Bookshelf.Domain.Books;
using Bookshelf.Domain.Reviews;
using HotChocolate.Types;

namespace Bookshelf.API.Books
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(book => book.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(book => book.Title)
                .Type<NonNullType<StringType>>();

            descriptor.Field(book => book.Description)
                .Type<NonNullType<StringType>>();

            descriptor.Field(book => book.ISBN)
                .Name("isbn")
                .Type<NonNullType<StringType>>();

            descriptor.Field(book => book.Published)
                .Name("published")
                .Type<NonNullType<DateType>>();

            descriptor.Field(book => book.Pages)
                .Name("pages")
                .Type<NonNullType<IntType>>();

            descriptor.Field(book => book.Authors)
                .Name("authors")
                .Type<NonNullType<ListType<NonNullType<AuthorType>>>>();

            descriptor.Field(book => book.Genres)
                .Name("genres")
                .Type<NonNullType<ListType<NonNullType<GenreType>>>>();

            descriptor.Field("rating")
                .Type<NonNullType<FloatType>>()
                .Resolve(context =>
                {
                    var id = context.Parent<Book>().Id;

                    return context.Service<IReviewRepository>().GetRatingByBookIdAsync(id);
                });
        }
    }
}
