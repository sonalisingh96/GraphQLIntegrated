using GraphQL.Types;
using WebApi.Data.Models;
using WebApi.Repository;

namespace WebApi.GraphQL
{
    public class BookMutation:ObjectGraphType
    {
        public BookMutation(BookRepository bookRepository)
        {
            FieldAsync<BookType>(
                "addBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "addBook" }),
                resolve: async context =>
                {
                    var addBook = context.GetArgument<Book>("addBook");
                    return await context.TryAsyncResolve(
                        async c => await bookRepository.AddBook(addBook));
                });
            FieldAsync<BookType>(
                "updateBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "updateBook" }),
                resolve: async context =>
                {
                    var updateBook = context.GetArgument<Book>("updateBook");
                    return await context.TryAsyncResolve(
                        async c => await bookRepository.UpdateBook(updateBook));
                });
            FieldAsync<BookType>(
                "deleteBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "deleteBook" }),
                resolve: async context =>
                {
                    var deleteBook = context.GetArgument<Book>("deleteBook");
                    return await context.TryAsyncResolve(
                        async c => await bookRepository.DeleteBook(deleteBook));
                });
        }
    }
}
