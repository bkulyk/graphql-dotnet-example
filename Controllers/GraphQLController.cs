//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//using GraphQL;
//using GraphQL.Types;

//namespace test.Controllers
//{
//    [Route("graphql")]
//    public class GraphQLController : Controller
//    {
//        [HttpGet]
//        public string Get(string query)
//        {
//            var schema = Schema.For(@"
//type Query {
//    hello: String
//}");
//            Response.ContentType = "application/json";
//            return schema.Execute(_ => { _.Query = query; });
//        }
//    }

//}
