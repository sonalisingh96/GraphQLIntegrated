using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace WebApi.GraphQL
{
    public class BookInputType: InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "bookInput";
            Field<NonNullGraphType<StringGraphType>>("author");
            Field< NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("isbn");
        }
    }
}
