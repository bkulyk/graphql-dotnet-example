using GraphQL;
using GraphQL.Types;

namespace GraphQL.StarWars
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IDependencyResolver resolver)
        {
            Query = resolver.Resolve<StarWarsQuery>();
        }
    }
}
