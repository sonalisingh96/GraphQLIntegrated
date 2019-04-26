using GraphQL.Types;
using WebApi.Data.Models;

namespace WebApi.GraphQL
{
    public class BookType:ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(t => t.Title);
            Field(t => t.Author);
            Field(t => t.Isbn);
        }
    }
}
