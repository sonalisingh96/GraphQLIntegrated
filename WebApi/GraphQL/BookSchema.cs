using GraphQL;
using GraphQL.Types;
namespace WebApi.GraphQL
{
    public class BookSchema:Schema
    {
        public BookSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BookQuery>();
            Mutation = resolver.Resolve<BookMutation>();
        }
    }
}
