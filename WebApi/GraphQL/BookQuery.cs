using GraphQL.Types;
using WebApi.Repository;

namespace WebApi.GraphQL
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(BookRepository bookRepository)
        {
            Field<ListGraphType<BookType>>(
                name: "book",
                description: "to get all the books",
                resolve: context => bookRepository.GetBooks()
            );
            Field<BookType>(
                name: "isbn",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "isbn" }),
                resolve: context =>
                {
                    var isbn = context.GetArgument<string>("isbn");
                    return bookRepository.GetBookByIsbn(isbn);
                }
            );
            Field<BookType>(
               name: "authorName",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "authorName" }),
                resolve: context =>
                {
                    var authorName = context.GetArgument<string>("authorName");

                    return bookRepository.GetBookByAuthorName(authorName);
                }
            );
            Field<ListGraphType<BookType>>(
              name:  "authorNameContains",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "authorName" }),
                resolve: context =>
                {
                    var authorName = context.GetArgument<string>("authorName");

                    return bookRepository.GetBookByAuthorNameContains(authorName);
                }
            );
        }
    }
}
