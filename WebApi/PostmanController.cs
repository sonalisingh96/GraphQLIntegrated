using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;


namespace WebApi
{
    [Route("Postman")]
    public class PostmanController:Controller
    {
        [HttpPost]
        public async Task<Book> AddReview(BookInputModel review)
        {
            using (GraphQLClient graphQlClient = new GraphQLClient("http://localhost:53536/graphql"))
            {
                var query = new GraphQLRequest
                {
                    Query = @" 
               mutation($review:bookInput!){
		              addBook(review:$review){
			            title
			            author
			            isbn
		              }
		            }",
                    Variables = new {review}
                };
                var response = await graphQlClient.PostAsync(query);
                return response.GetDataFieldAs<Book>("addBook");
            }
        }
    }
}
